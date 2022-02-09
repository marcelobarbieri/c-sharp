using System.IO.Compression;
using Zip.Models;

var arq = new Arquivo();

// --- vários arquivos

// arquivos compactados através de um diretório
// arq.diretorio = "C:/TEMP/Zip/";
// arq.nome = "Zip.zip";
// ZipFile.CreateFromDirectory($@"{arq.diretorio}", $@"{arq.diretorio}{arq.nome}");

// para descompactar é só fazer o inverso
// arq.diretorio = "C:/TEMP/";
// arq.nome = "teste.zip";
// ZipFile.ExtractToDirectory($@"{arq.diretorio}{arq.nome}", $@"{arq.diretorio}");


// --- um único arquivo ou vários arquivos

// aqui pode usar o ZipArchiveMode.Update caso o arquivo já exista e então é adicionado mais um arquivo ao ficheiro
arq.diretorio = "C:/TEMP/";
arq.nome = "teste2.zip";
using (ZipArchive archive = ZipFile.Open($@"{arq.diretorio}{arq.nome}", ZipArchiveMode.Create))
{
    archive.CreateEntryFromFile($@"C:\Temp\Novo Documento RTF.rtf", "Novo Documento RTF.rtf");
    archive.CreateEntryFromFile($@"C:\Temp\Novo(a) Apresentação do Microsoft PowerPoint.pptx", "Novo(a) Apresentação do Microsoft PowerPoint.pptx");
}