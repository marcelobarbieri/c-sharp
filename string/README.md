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

// Cria uma string informando um valor inicial
var meuTexto = "valor";

// Cria uma string vazia
var meuTexto = string.Empty;

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

## String Builder

Tem a finalidade de concatenar **strings**.

É normal vermos o uso da concatenação de strings utilizando o operador de atribuição **+=** do C#, o que pode não ter muito efeito negativo em cadeias de caracteres pequenas, mas em longos textos pode se tornar um grande vilão.

```c#
var meuTexto = "Olá mundo";
meuTexto += " aqui vai mais um";
meuTexto += " e aqui mais um pedaço da string";
```

Para cada concatenação uma terceira variável é gerada com o conteúdo das anteriores se acumulando. Imagine este cenário com muitas concatenações!

Para isto, existe o **StringBuilder** (construtor de strings) feito sob medida para esta demanda de concatenação de textos.

```c#
var meuTexto = new StringBuilder();
meuTexto.Append("Olá mundo");
meuTexto.Append(" aqui vai mais um");
meuTexto.Append(" e aqui mais um pedaço da string");

Console.WriteLine(meuTexto.ToString());
```

No exemplo acima temos um código muito mais otimizado, utilizando o **StringBuilder** para construir um texto longo que é baseado em outras cadeias de caracteres.

Notamos também que por se tratar de um objeto complexo, precisamos do método **ToString()** para imprimir o valor do texto composto na tela.

> Interpolação de strings

Não confundir a **concatenação de strings** com a **interpolação de strings**

Pode-se usar a interpolação sempre que precisar, e uma das melhores formas é sinalizar isto ao compilador utilizando o **$** antes da mesma.

```c#
var meuTexto = "Mundo";
var outroTexto = $"Olá {meuTexto}"
```

# Referências

- [Balta.io](https://balta.io/blog/csharp-string-systemstring-stringbuilder)
