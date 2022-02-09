# Compactação de arquivos

> Compactar vários arquivos de uma pasta

```c#
//Arquivos compactados através de um diretório
ZipFile.CreateFromDirectory(@".\pathFilesForCompress", @".\resultFileNameCompress.zip");

//Para descompactar é só fazer o inverso
ZipFile.ExtractToDirectory(@".\resultFileNameCompress.zip", @".\pathExtractFiles");
```

> Compactar um único arquivo

```c#
//Aqui pode usar o ZipArchiveMode.Update caso o arquivo já exista e então é adicionado mais um arquivo ao ficheiro
using (ZipArchive archive = ZipFile.Open(@".\resultFileNameCompress.zip", ZipArchiveMode.Create))
archive.CreateEntryFromFile(@"C:\Temp\MeuArquivo.txt", "MeuArquivo.txt");
```
