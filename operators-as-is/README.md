# Operadores as e is no C#

## Operador IS

Operador de comparação para tipos primitivos ou complexos.
Elimina a necessidade do **typeof**

```c#
var someText = "This is a string";

// retorna bool
var result = someText.GetType() == typeof(string);
```

```c#
var result = someText is string;
```

> Tipos Complexos

Tipos: class, record

```c#
public record Documento { ... }
public record CPF : Documento { ... }
public record CNPJ : Documento { ... }
```

```c#
var p = new Passaporte();
if (p is Documento)
    Console.WriteLine("P é um documento");
```

> Comparação de nulos

```c#
if (student == null)
    Console.WriteLine("Nulo");

if (student != null)
    Console.WriteLine("Não Nulo");
```

```c#
if (student is null)
    Console.WriteLine("Nulo");

if (student is not null)
    Console.WriteLine("Não Nulo");
```

## Operador AS

Conversão explícitas de objetos.

```c#
var documento = new Documento();
var cpf = (CPF)documento;
```

```c#
var documento = new Documento();
var cpf = documento as CPF;
```

# Referências

- [Balta.io](https://balta.io/blog/csharp-as-is)
