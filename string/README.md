# String, System.String e StringBuilder no C#

## String ou string

> string - cadeia de caracteres que representa um tipo de valor e pode armazenar até 1 bilhão de caracteres e 2GB de memória.

```c#
// Cria uma string vazia
// Receberá warning de possível referência nula a partir do .NET 6
string meuTexto;

// Cria uma string informando um valor inicial
string meuTexto = "valor";

// Cria uma string vazia
string meuTexto = string.Empty;

// ERRO
var meuTexto;

// Cria uma string (Nula) que permite nulos
string? meuTexto;
```

Para permitir valores nulos em um **string** precisamos do **?** após sua definição.

**string.Empty** é um **sintax sugar** para "". Define um valor vazio para um **string**. Em alguns cenários o **string.Empty** não é permitido por não ser considerado uma constante.

> Qual a diferença entre String e string?

```c#
string meuTexto = "andre";
String umValor = "algum valor";
```

Embora **string** (toda minúscula) seja a mais utilizada, o tipo correto para **strings** no C# é o **System.String** ou somente **String** ("S" maiúsculo)

Todo tipo no .NET deriva do tipo base **System** e no caso das **strings** não é diferente. Desta forma, mantendo o padrão de todos os tipos no C#, a **string** tem seu **namespace**/tipo definidos como **Sytem.String**

O mesmo acontece com os tipos:

- **Int16** que é comumente chamado de **short**,
- **Int32** que é chamado de **int** e
- **Int64** que é chamado de **long**.

Por convenção, toda classe/estrutura no .NET começa com letra maiúscula.

Então os tipos que usamos tanto, como **short**, **int**, **string**, **bool**, **float**, **double** não passam de **sintax sugar** ou **alias** (apelido) para os tipos reais no .NET

> Na prática o que isto muda?

# Referências

- [Balta.io](https://balta.io/blog/csharp-string-systemstring-stringbuilder)
