# Gerando arquivos CSV (Excel) no C#

Gerar arquivos CSV (Excel) utilizando C# e **Implicit Operators**.

## O que são arquivos CSV?

**CSV** é a sigla para **Comma Separated Values**, ou **valores separados por vírgula**. Estes tipos de dados são comuns de serem encontrados e podem ser facilmente editados pelo Excel.

Os arquivos **CSV** nada mais são do que arquivos textos, com conteúdo em um formato específico e a extensão **\*.csv**.

Sempre que falamos em exportar para o Excel, **CSV** é minha primeira opção, pela facilidade que temos em manipular este tipo de arquivo.

### Exemplo

```csv
nome,telefone,datanasc
Bruce Wayne,5599999999999,12/08/1984
Bruce Banner,5599999999997,11/08/1979
Peter Parker,5599999999996,12/07/1992
Tony Stark,5599999999995,10/06/1988
```

## Modelo

```c#
public class Hero
{
    public string Name { get; set; }
    public string Phone { get; set; }
    public DateTime BirthDate { get; set; }
}
```

Com o modelo definido faz-se necessário converter seus valores para uma **String**, separando-os por vírgula.

_IMPORTANTE: A ordem dos campos deve seguir o cabeçalho do arquivo (primeira linha)._

### Implicit Operators

Facilita a conversão de tipos no C#.

No método abaixo, é retornado uma **String** com os valores separados por vírgula.

```c#
public static implicit operator string(Hero hero)
    => $"{hero.Name},{hero.Phone},{hero.BirthDate.ToString("yyyy-MM-dd")}";
```

Já a conversão de um item do **CSV** para o objeto **Hero** é um pouco mais complicada, pois neste caso, tem-se uma data que não poderá ser convertidade de uma **String** diretamente.

Os **Extensions Methods** podem ser um ótimo caminho pois adicionam funcionalidades a outras classes, incluindo as nativas do .NET.

Neste caso, por exemplo, pode-se criar um método que adiciona a funcionalidade de converter uma **String** para um **DateTime**

```c#
public static class StringExtension
{
    public static DateTime ToDateTime(this string value)
    {
        var data = value.Split("-");
        return new DateTime(
            int.Parse(data[0]),
            int.Parse(data[1]),
            int.Parse(data[2]));
    }
}
```

Com a extensão criada, o método ToDateTime() está disponível em todas as **String** do projeto.

Conversão de um item **CSV** para o objeto.

```c#
public static implicit operator Hero(string line)
{
    var data = line.Split(",");
    return new Hero(
        data[0],
        data[1],
        data[2].ToDateTime());
}
```

Resultado final da classe **Hero**

```c#
public class Hero
{
    public Hero(string name, string phone, DateTime birthDate)
    {
        Name = name;
        Phone = phone;
        BirthDate = birthDate;
    }

    public string Name { get; set; }
    public string Phone { get; set; }
    public DateTime BirthDate { get; set; }

    public static implicit operator string(Hero hero)
        => $"{hero.Name},{hero.Phone},{hero.BirthDate.ToString("yyyy-MM-dd")}";

    public static implicit operator Hero(string line)
    {
        var data = line.Split(",");
        return new Hero(
            data[0],
            data[1],
            data[2].ToDateTime());
    }
}
```

## Gerando CSV

Com as conversões finalizadas, será feito uso da leitura e escrita de arquivos que o .NET fornece para gerar o **\*.csv**

Criação da lista de heróis.

```c#
var heroes = new List<Hero>
{
    new("Bruce Wayne", "5599999999996", DateTime.Now.AddYears(-40)),
    new("Bruce Banner", "5599999999997", DateTime.Now.AddYears(-38)),
    new("Peter Parker", "5599999999996", DateTime.Now.AddYears(-18)),
    new("Tony Stark", "5599999999996", DateTime.Now.AddYears(-33)),
};
```

Em seguida, pode-se utilizar o método **File.WriteAllLines** do .NET, que escreve uma lista de **String** no formato de linhas.

Será necessário utilizar o **LINQ** para transformar uma lista de **String** para uma lista de **Hero**

```c#
heroes.Select(hero => (string) hero);
```

Foi necessário explicitar o tipo de conversão para **String** pois o **LINQ** não é capaz de inferir.

Resultado final

```c#
File.WriteAllLines("heroes.csv", heroes.Select(hero => (string) hero).ToList());
```

```
Bruce Wayne,5599999999996,1982-01-07
Bruce Banner,5599999999997,1984-01-07
Peter Parker,5599999999996,2004-01-07
Tony Stark,5599999999996,1989-01-07
```

## Lendo um CSV

Existe o método **File.ReadAllLines** do .NET que retorna uma lista de **String**

Com a lista de **String**, tem-se o operador implícito que converte o tipo para **Hero**

```c#
var data = File.ReadLines("heroes.csv");
foreach (var line in data)
{
    Hero hero = line;
    Console.WriteLine(hero.Name);
    Console.WriteLine(hero.Phone);
    Console.WriteLine(hero.BirthDate);
    Console.WriteLine("--");
}
```

```
Bruce Wayne
5599999999996
01/07/1982 00:00:00
--
Bruce Banner
5599999999997
01/07/1984 00:00:00
--
Peter Parker
5599999999996
01/07/2004 00:00:00
--
Tony Stark
5599999999996
01/07/1989 00:00:00
--
```

# Referências

> [Balta.io](https://balta.io/blog/csharp-gerar-csv)
