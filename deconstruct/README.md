# Deconstruct no C#

Desconstruir um objeto e obter de forma fácil e simples suas propriedades.

O método **Deconstruct** não deve ser confundido com o método destrutor do objeto (i.e., ~Metodo()).
Deconstruir é diferente de destruir.

**Deconstruct**

- funcionará de forma similar aos tipos built-in do .NET que podem ser exetendidos (métodos de extensão);
- deve ser inserido dentro de uma classe de extensão.

#

Criação de classe estática (obrigatória)

```c#
public static class DateTimeExtensions
{
    // ...
}
```

## Implementação

A diferença entre um método de extensão (Extensio Method) comum e um **Deconstruct** é o nome deste.
O nome deve ser obrigatoriamente **Deconstruct**

A classe **DateTimeExtensions** é uma extensão para **DateTime**, por isso será passado um parâmetro de entrada para o **Deconstruct()** (i.e., **this DateTime dateTime**)

```c#
public static class DateTimeExtensions
{
    public static void Deconstruct(this DateTime dateTime)
    {
        // ...
    }
}
```

O método deve retornar algum valor, neste caso, será descontruído (desmembrado) um objeto em variáveis (i.e., **out int year, out int month, out int day**).

```c#
public static class DateTimeExtensions
{
    public static void Deconstruct(
        this DateTime dateTime,
        out int year, out int month, out int day)
    {
        // ...
    }
}
```

Foi utilizada a palavra reservada **out** pois o método **Deconstruct** é do tipo **void** e não possui retorno específico.
Neste caso será criadas 3 (três) variáveis do tipo inteiro.

Assimilar as variáveis aos valores do **DateTime**

```c#
public static class DateTimeExtensions
{
    public static void Deconstruct(
        this DateTime dateTime,
        out int year, out int month, out int day)
    {
        year = dateTime.Year;
        month = dateTime.Month;
        day = dateTime.Day;
    }
}
```

## Melhorando o Código

> Tuplas

```c#
public static class DateTimeExtensions
{
    public static void Deconstruct(
        this DateTime dateTime,
        out int year, out int month, out int day)
    {
        (year, month, day) = (dateTime.Year, dateTime.Month, dateTime.Day);
    }
}
```

> Expression Body

```c#
public static class DateTimeExtensions
{
    public static void Deconstruct(
        this DateTime dateTime,
        out int year, out int month, out int day)
        => (year, month, day) = (dateTime.Year, dateTime.Month, dateTime.Day);
}
```

## Utilizando o Deconstruct

Basta assimilar uma **Data/Hora** a uma variável que seja uma **Tupla** esperando três valores.

```c#
var (year, month, day) = DateTime.Now;

Console.WriteLine(year);
Console.WriteLine(month);
Console.WriteLine(day);
```

# Referência

- [Balta.io](https://balta.io/blog/csharp-deconstruct)
