// --- Action

Action acao;

acao = MinhaFuncao;

acao();

void MinhaFuncao()
{
    Console.WriteLine("Eu sou uma função");
}

// --- Funções Anônimas

Action acao;

acao = () => MinhaFuncao("Eu sou um parâmetro");

acao();

void MinhaFuncao(string texto)
    => Console.WriteLine(texto);

// --- Action Chaining

Action handle;

handle = VerificaRequisicao;
handle += VerificaSeEmailEstaEmUso;
handle += GeraOUsuario;
handle += GeraOAluno;
handle += PersisteOsDados;
handle += EnviaCodigoDeAtivacao;
handle += LogaANovaContaCriada;

handle();

void VerificaRequisicao() { }
void VerificaSeEmailEstaEmUso() { }
void GeraOUsuario() { }
void GeraOAluno() { }
void PersisteOsDados() { }
void EnviaCodigoDeAtivacao() { }
void LogaANovaContaCriada() { }