# Extension Methods no C#

**Extension Methos** ou métodos de extensão possibilita adicionar funcionalidades extras a qualquer tipo no C#.

## Extension Methods

Os **Extension Methods** no C# são classes estáticas que podem viver fora das suas classes e ainda assim adicionar funcionalidades à mesmo, permitindo, dentre outras coisas, uma melhor organização do código.

Exemplo: cenário onde é necessário converter uma **String** para **DateTime**. Embora exista o **Cast**, seria melhor existir um método **ToDateTime** em qualquer **String**.

Não é possível modificar o código interno do .NET, mas é possível extendê-lo.

Criação de um método adicional na **String** do .NET.

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

Foi necessária uma classe e um método **static** e adicionar a palavra reservada **this** antes do tipo do parâmetro de entreda.

Com isso, pode-se usar o método **ToDateTime** em qualquer **String** do sistema.

```c#
var minhaData = "2022-01-10";
var data = minhaData.ToDateTime(); // converte a String para DateTime
```

## Extensão de Objetos

Exemplo de uma entidade chamada **Couse** que representa um curso com suas propriedades.

```c#
public class Course : Entity
{
    public string Title { get; set; }
    public string Summary { get; set; }
    public string Url { get; set; }
    public EContentLevel Level { get; set; }
    public int DurationInMinutes { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime LastUpdateDate { get; set; } = DateTime.UtcNow;
    public bool Active { get; set; } = true;
    public bool Free { get; set; } = false;
    public bool Featured { get; set; } = false;
    public Guid AuthorId { get; set; }
    public Author Author { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
    public string Tags { get; set; }
}
```

Isso faz todo o sentido para o modelo, para o reflexo do objeto em relação ao banco de dados, mas não faz sentido para as telas, as views, o que o usuário vê. Na verdade, o usuário enxerta uma porcentagem bem menor de informações.

Para isto, existem **ViewModels** ou **DTOs** que são modelos especiais que servem como transporte de dados de um lugar para outro. Neste caso, da camada mais abaixo para a camada de apresentação, o ASP.NET.

```c#
public class CourseCardViewModel
{
    public string Title { get; set; }
    public string Url { get; set; }
    public EContentLevel Level { get; set; }
    public int DurationInMinutes { get; set; }
}
```

Os **Extension Methods** se encaixam exatamente nesta parte, onde temos uma lista de cursos **List<Course>** que vem do cache e é necessário convertê-la para **List<CourseCardViewModel>**

A abordagem do **método construtor** para criar uma sobrecarga que recebe **Course** e faz a conversão funciona bem, mas com a conversão de diversos objetos, o código pode ficar bastante extenso.

```c#
public class CourseCardViewModel
{
    public CourseCardViewModel(Course course)
    {
        // Preenche as propriedades
    }

    public string Title { get; set; }
    public string Url { get; set; }
    public EContentLevel Level { get; set; }
    public int DurationInMinutes { get; set; }
}
```

### Conversão da lista de cursos

O exemplo abaixo converte uma lista de **Course** em uma lista de **CourseViewModel**

```c#
courses.Select(x => new CourseCardViewModel(x));
```

## Aplicando Extension Methods

Neste caso, opta-se por uma pasta chamada **Extensions** onde as extensões são organizadas por **features**.

```c#
public static class CourseExtensions
{
    public static CourseCardViewModel ToCard(Course course)
    {
        // Gera um novo ViewModel e retorna
    }
}
```

Com isso, pode-se criar quantas extensões forem necessárias para **Course** sem modificar o código ou a **ViewModel**, e seu uso fica siomples.

### Convertendo a lista de cursos

O exemplo abaixo converte uma lista de **Course** em uma lista de **CourseViewModel**

```c#
courses.Select(x.ToCard());
```

## Conclusão

Os métodos de extensão permitem adicionar funcionalidades a qualquer tipo, **built-in** ou complexo no C#, de forma simples, fácil e organizada, separando este comportamento adicional da classe base.

# Referências

> [Balta.io](https://balta.io/blog/csharp-extension-methods)
