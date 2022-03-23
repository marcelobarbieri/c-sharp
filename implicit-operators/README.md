# Implicit Operators no C#

**Implict Operators** permitem adicionar comportamentos de conversão a objetos **Built in** ou complexos, de maneira que o compilador possa entende-las de forma implícita.

## O que são conversões explícitas e implícitas

Conversões implícitas são aquelas feitas pelo **runtime** de forma automática, que ele entende naturalmente, como por exemplo:

```c#
int x = 100;
double y = x;
```

Neste caso, foi possível converter **x** de **int** para **double** naturalmente, afinal os números reais suportam inteiros. Porém o mesmo não ocorre neste caso.

```c#
double x = 100.0;
int y = x;
```

Os números inteiros não são capazes (pelo menos não sozinhos) de resolver números reais. Neste caso, é necessário explicitar a conversão.

```c#
double x = 100.98;
int y = (int) x;

Console.WriteLine(y); // 100, ignora o que vem depoios do "."
```

## O que são Implicit Operators

Os **Implict Operators** são formas de dizer ao compilador como resolver uma conversão de forma implícita, o que diminui a quantidade de código escrita.

No segundo cenário, onde o compilador não sabe como converter um **double** para **int** naturalmente, de forma implícita. Neste caso, pode-se criar um método dizendo como isso pode ser feito, ignorando os valores depois do "." por exemplo. Tem-se, assim, a possibilidade de converter **double** para **int** facilmente.

## Implict Operators com Strings

O exemplo acima foi apenas para entendimento dos **Implict Operators**.

Algo que é feito com muita frequência é sobrescrever o método **ToString** que todo objeto no .NET possui.

> Todo objeto no .NET deriva de uma classe base chamada **Sytem** que possui o método **ToString** com o modificador **Virtual**, permitindo o mesmo ser reescrito.

No caso abaixo, tem-se um **Objeto de Valor** e seu método **ToString** sendo sobrescrito.

```c#
public class Phone
{
    public string CountryCode { get; set; }
    public string Area { get; set; }
    public string Number {get; set; }

    public override string ToString()
    {
        return $"+{CountryCode} ({Area}) {Number}";
    }
}
```

Desta forma, sempre que quiser exibir o telefone na tela, basta chamar **phone.ToString()** ou em casos de interpolação de string **$"Meu telefone é {phone}"** que a conversão será realizada.

## Convertendo para Implicit Operators

Este cenário é um caso legal para refatoração, onde os **Implicit Operators** cairiam muito bem, fazendo não só o papel de converter uma **String** para um telefone quanto um telefone (Objeto) para uma **String**

```c#
public record Phone(string CountryCode, string Area, string Number)
{
    public static implicit operator string(Phone phone) => $"+{phone.CountryCode} ({phone.Area}) {phone.Number}";

    public static implicit operator Phone(string phone)
    {
        var data = phone.Split(" ");
        return new Phone(data[0], data[1], data[2]);
    }
}
```

Desta forma, podemos utilizar o objeto recebendo um **String** ou se convertendo automaticamente para uma, de forma simples e prática.

```c#
// cria um telefone (objeto)
var phone = new Phone("55", "11", "999999999");
// converte para string
Console.WriteLine(phone); // +55 (11) 999999999

// cria uma string
var telephone = "55 11 987765544";
// converte para um telefone (objeto)
phone = telephone;
Console.WriteLine(phone); // +55 (11) 987765544
```

## DTOs e ViewModels

Entidade **User** com as seguintes propriedade:

```c#
public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public bool Active { get; set; }
}
```

Deseja-se exibir apenas algumas propriedades deste usuário, ocultar a senha por exemplo. Parte-se para a criação de um **DTO** ou **ViewModel**

```c#
public class UserViewModel
{
    public UserViewModel(string userName)
        => UserName = userName;

    public string UserName { get; }
}
```

Neste caso, pode-se fazer uso dos **Implicit Operators** para criar um método que converte **User** em **UserViewModel**.

```c#
public static implicit operator UserViewModel (User user)
    => new UserViewModel(user.Username);
```

Como resultado, tem-se o seguinte código no **UserViewModel**

```c#
public class UserViewModel
{
    public UserViewModel(string userName)
        => UserName = userName;

    public string UserName { get; }

    public static implicit operator UserViewModel(User user)
        => new UserViewModel(user.Username);
}
```

A conversão de **User** para **UserViewModel** e vice-versa pode ser veita de forma simples e fácil.

```c#
// cria uma instancia de um usuário
var user = new User
{
    Id = 1,
    Username = "balta",
    Password = "balta1234",
    Active = true
}

// cria uma instancia do ViewModel
// recebe um usuário (conversão implícita)
UserViewModel viewModel = user;
```

# Referências

[Balta.io](https://balta.io/blog/csharp-implicit-operators)

[Microsoft](https://docs.microsoft.com/en-us/dotnet/api/microsoft.sqlserver.management.assessment.expressions.expression.op_implicit?view=sql-smo-160)

[Youtube](https://www.youtube.com/watch?v=2UVsT3TEVTw)
