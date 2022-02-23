
        private async Task DownloadCertificado()
        {
            try
            {
                //Busca parâmetro de download de certificado                
                var paramDownloadCertificado = (await _readParam.ValorParametro<String>(null, _parametroDownloadCertificado, null).ConfigureAwait(false)).FromJson<ParametroDownload>();
                if (paramDownloadCertificado == null || paramDownloadCertificado?.Ativa == false) return;

                //Sai da rotina se o último download foi a menos de 24 horas
                //Bacen permite apenas um download de certificado a cada 24 horas
                if ((DateTime.Now - ultimoDownloadCertificado).TotalHours < 24) return;

                //Cria diretório para download do arquivo
                if (!Directory.Exists(paramDownloadCertificado.Diretorio)) Directory.CreateDirectory(paramDownloadCertificado.Diretorio);

                var requestUri = $"{_urlApiSpiPrincipal}{_absolutePath}{HttpUtility.UrlEncode(paramDownloadCertificado.URL)}";

                try
                {
                    if (httpClient == null)
                        httpClient = new HttpClient();
                }
                catch (Exception ex)
                {
                    _logEvt.LogInformation($"Erro ao criar o httpClient: {ex}");
                    if (httpClient == null) return;
                }

                _logEvt.LogInformation("Chamada da api para download dos certificados.");

                using (var response = await httpClient.GetAsync(requestUri).ConfigureAwait(false))
                {
                    if (response.StatusCode.NotEquals(System.Net.HttpStatusCode.OK))
                    {
                        _logEvt.LogInformation($"Erro no retorno da API. Código de retorno {response.StatusCode}");
                        return;
                    }

                    var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var retorno = JsonConvert.DeserializeObject<DownloadArquivoReturnValue>(content);

                    //Grava o conteudo do download em arquivo zip
                    var strNomeArquivo = Path.Combine(paramDownloadCertificado.Diretorio, DateTime.Now.ToString("yyyyMMddHHmm") + "Certificados.zip");
                    await File.WriteAllBytesAsync(strNomeArquivo, retorno.Conteudo);

                    //Extrai o arquivo zip no mesmo diretório
                    ZipFile.ExtractToDirectory(strNomeArquivo, paramDownloadCertificado.Diretorio, true);

                    //Apaga o arquivo
                    File.Delete(strNomeArquivo);
                }

                //Seta a data de último download 
                ultimoDownloadCertificado = DateTime.Now;
            }
            catch (Exception erro)
            {
                _logEvt.LogException(erro);
                if (httpClient != null)
                {
                    httpClient.Dispose();
                    httpClient = new HttpClient();
                }
            }
        }