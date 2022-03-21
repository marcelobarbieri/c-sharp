# Manipulação de arquivos no C#

Cria, copiar, substituir, ler e escrever arquivos em C#.

## System.File

O .NET é um conjunto de bibliotecas (Framework) que auxilia na criação de aplicações. Manipular arquivos é algo comum em boa parte dos sistemas.

O .NET traz o **System.File**, uma **lib** completa para manipulação de arquivos em qualquer plataforma que suporta o .NET.

> IMPORTANTE: Existe alguns métodos como o **File.Encrypt** que roda exclusivamente no Windows. Neste caso o compilador e/ou IDE alertará sempre que for utilizado método específico de determinada plataforma

Para facilitar todos os exemplos a seguir será criada uma constante que definirá o caminho do arquivo.

```c#
const string filePath = @"C:\DEV\C#\files\meuarquivo.txt";
```

## Tratamento de erros

A manipulação de arquivos é sensível. Recomenda-se a utilização de **try/catch**

```c#
try {
    // manipulação de arquivo
} catch (Exception ex) {
    // capturar a exceção
}
```

## Criar arquivo

**File.Create** cria ou sobrescreve arquivos no disco. Caso não exista, o arquivo será criado. Se já existe, será sobrescrito.

O caminho deve existir, caso contrário haverá uma exceção do tipo **DirectoryNotFoundException**. O caminho não é criado automaticamente.

Também, caso não haja permissão para escrita do arquivo no diretório informado haverá outra exceção do tipo **UnauthorizedAccessException**

```c#
File.Create(filePath);
```

## Adicionar conteúdo a um arquivo

Para adicionar conteúdo (escrever) em um arquivo, pode-se usar os métodos **AppendText** ou **CreateText**.

**AppendText** adiciona texto ao final do arquivo.

**CreateText** sobrescreve o conteúdo do arquivo com o texto informado.

```c#
// adiciona texto no final do arquivo
using var file = File.AppendText(filePath);
file.WriteLine("Teste");
file.Close();

// substitui o conteúdo do arquivo
using var file = File.CreateText(filePath);
file.WriteLine("Teste2");
file.Close
```

É importante nota que ao manipular arquivos grandes não é necessário ler o arquivo completamente para adicionar conteúdo ao mesmo. Neste caso é preferível utilizar **AppendText**

```c#
// ERRADO
var data = File.ReadText(filePath);
data += "Meu texto adicional";
// substitui o conteúdo do arquivo
using var file = File.CreateText(filePath);
file.WriteLine(data);

// CORRETO
// adiciona texto no final do arquivo
using var file = File.AppendText(filePath);
file.WriteLine("Meu texto adicional");
file.Close();
```

> IMPORTANTE: Em caso de arquivos grandes recomenda-se a utilização do **StreamWrite** para escrita e **StreamReader** para leitura

## Copiar um arquivo

Para copiar um arquivo utiliza-se **File.Copy** com a informação completa do arquivo de origem e destino.

```c#
File.Copy(filePath, @"C:\DEV\C#\files\outro.txt")
```

É importante notar que, neste caso, se houver outro arquivo com o mesmo nome, haverá uma exceção. Para sobrescrever o arquivo de destino, caso já exista, utilizar o parametro adicional para **overwrite** no método **Copy**

```c#
// sobrescreve o arquivo de destino caso exista
File.Copy(filePath, @"C:\DEV\C#\files\outro.txt", overwrite: true);
```

## Mover um arquivo

Para mover um arquivo utiliza-se **File.Move**.

```c#
File.Move(filePath,@"C:\DEV\C#\files\outro.txt", overwrite: true);
```

## Substituir um arquivo

Para substituir um arquivo utiliza-se **File.Replace**.

```c#
File.Replace(@"C:\DEV\C#\files\outro.txt", filePath, @"C:\DEV\C#\files\backup.txt");
```

## Excluir um arquivo

Para excluir um arquivo utiliza-se **File.Delete**. Será exibida exceção caso o arquivo não seja encontrado ou não possa ser excluído.

```c#
File.Detele(filePath);
```

## Verificar se um arquivo existe

Para verificar se um arquivo existe utiliza-se **File.Exists** informando o caminho completo do arquivo. Esse método retorna **true** ou **false** para dizer se o arquivo existe ou não.

```c#
File.Exists(filePath); // retorna booleano
```

## Abertura e leitura de arquivos

### Lendo arquivos em C#

Ler arquivos em C# não é uma tarefa difícil e a forma mais simples e direta pe utilizar o método **ReadAllText** da classe estática **File**

No exemplo abaixo, o programa faz a leitura de um arquivo e exibe seu conteúdo na tela, sem iterar.

```c#
var data = File.ReadAllText(@"C:\DEV\C#\files\meuarquivo.txt");
Console.WriteLine(data);
```

### Lendo arquivos em C# linha a linha

Para iterar pelas linhas do arquivo pode-se utilizar o método **ReadAllLines** que retorna um **Array** de **String** que pode ser iterado.

No exemplo abaixo o programa faz a leitura do arquivo e exibe seu conteúdo na tela, com iteração.

```c#
var lines = File.ReadAllLine(@"C:\DEV\C#\files\meuarquivo.txt");
foreach (var line in lines)
    Console.WriteLine(line);
```

### StreamReader

A leitura de arquivos linha a linha, caso o arquivo seja muito grande, ler ele por completo pode acarretar estouro de memória.

Por isso, utilizar o **StreamReader** em conjunto com **using** a leitura do arquivo será realizada em blocos (streaming).

Sempre que é realizado um **Stream**, ocorre a possibilidade do arquivo ficar aberto por mais tempo que o necessário em memória. Por isso é quase que obrigatório o uso do **Dispose** que neste caso já é feito pelo **using**.

No exemplo abaixo, o programa fará a leitura do arquivo e exibirá seu conteúdo na tela.

```c#
using var file = new StreamReader(@"C:\DEV\C#\files\meuarquivo.txt");
string? line;

while ((line = file.ReadLine()) != null)
    Console.WriteLine(line);

file.Close();
```

## Obter data de última modificação do arquivo

**File.GetLastAccessTime** retorna a data e hora do último acesso ao arquivo.

```c#
var time = File.GetLastAccessTime(filePath); // retorna DateTime
Console.WriteLine(time);
```

## Obter atributos do arquivo

**File.GetAttributes** retorna um **enumerador** com os atributos do arquivo

```c#
var attrs = File.GetAttributes(filePath);
if ((attrs & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
    Console.WriteLine("read-only");

if ((attrs & FileAttributes.Compressed) == FileAttributes.Compressed)
    Console.WriteLine("compressed");
```

## Conclusão

O **System.File** possui um enorme leque de opções para manipulação de arquivos. Seu uso é simples e direto.

Atenção apenas ao tratamento de erros pela sensibilidade na leitura e escrita dos arquivos.

# Referências

[Manipulação de arquivos no C#](https://balta.io/blog/csharp-manipulacao-arquivos)

[Lendo arquivos em C#](https://balta.io/blog/lendo-arquivos-em-csharp)
