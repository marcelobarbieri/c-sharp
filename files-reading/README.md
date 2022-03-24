# Lendo arquivos em C#

Leitura de arquivos em C# com o menor esforço possível.

## Lendo arquivos em C#

Ler arquivos em C# não é uma tarefa difícil.
A forma mais simples e direta de fazer isto é utilizando o método **ReadAllText** da classe estática **File**.

No exemplo abaixo, o programa faz a leitura de um arquivo e exibe seu conteúdo na tela utilizando **Console.WriteLine**

```c#
// le um arquivo inteiro
var data = File.ReadAllText(@"C:\text-file.txt");
Console.WriteLine(data);
```

## Lendo arquivos em C# linha a linha

No método anterior, não foi iterado sobre o arquivo, apenas seu conteúdo foi lido e exibido na tela.

Para iterar pelas linhas do arquivo, tem-se um método chamado **ReadAllLines** que retorna um **Array** de **String**, que pode ser iterado futuramente.

No exemplo abaixo, tem-se um programa completo que faz a leitura de um arquivo e exibe seu conteúdo na tela utilizando o **Console.WriteLine**

```c#
// le um arquivo linha a linha
var lines = File.ReadAllLines(@"C:\text-file.txt");
foreach (var line in lines)
    Console.WriteLine(line);
```

## StreamReader

Uma outra forma muito utilizada é a leitura de arquivos linha a linha.
Na verdade, se um arquivo é muito grande, ler ele por completo pode acarretar em estouro de memória.

Para isto, uma ótima solução é utilizar o **StreamReader** em conjunto ao **using** que fará a leitura do arquivo em blocos (**Streaming**)

Toda vez que um **Stream** é realizado, ocorre a possibilidade do arquivo ficar aberto por mais tempo que o necessário em memória, por isto é quase que obrigatório o uso do **Dispose** que neste caso já é feito pelo **using**

No exemplo abaixo, tem-se um programa completo que faz a leitura de um arquivo e exibe seu conteúdo na tela utilizando o **Console.WriteLine**

```c#
using var file = new StreamReader(@"c:\text-file.txt");
string? line;

while((line = file.ReadLine()) != null)
    Console.WriteLine(line);

file.Close();
```

# Referências

[Balta.io](https://balta.io/blog/lendo-arquivos-em-csharp)
