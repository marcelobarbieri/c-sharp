# Obsessão por tipos primitivos (primitive obsession)

**Code smell**

A palavra **obsessão** significa: apego exagerado, motivação irresistível.

Uso exagerado e não justificado de tipos primitivos de forma que os valores dos tipos primitivos controlam a lógica do objeto.

## Sintomas da obsessão por primitivos

Relação dos sintomas:

- O código se baseia de forma exagerada em tipos primitivos como: string, int, bool, guid, etc;
- O código usa tipos primitivos ao invés de pequenos objetos para tarefas simples como definir : Moeda, CPF, Telefone, Nome, etc;
- O código usa constantes para informações de codificação (como USER_ADMIN_ROLE = 1 para se referir a usuários com direitos de administrador);
- O código usa constantes string como nomes de campo para uso em array de dados;

Motivações:

- É mais fácil usar apenas um tipo primitivo para armazenar um campo em vez de criar uma nova classe para ele;
- Freqüentemente, os tipos primitivos são usados para simular um tipo. Em vez de um objeto separado, você tem um conjunto de números ou strings aceitáveis que recebem nomes compreensíveis por meio de constantes;
- Às vezes, em vez de criar um novo campo ou um objeto, os dados podem ser apenas inseridos em uma coleção de dados;

## Os problemas causados pela obsessão por primitivos

### 1. Intercambiáveis

Um dos principais problemas com a obsessão por tipos primitivos é que **os valores do mesmo tipo podem ser substituídos uns pelos outros** sem quebrar o compilador, mesmo que sejam duas coisas diferentes. Por exemplo, um número de telefone e um nome são dois conceitos separados e não devem ser representados como strings.

Para mostrar isso vamos criar uma classe **Pessoa**:

```c#
public class Pessoa
{
    public Pessoa(string nome, string telefone)
    {
        Nome = nome;
        Telefone = telefone;
    }
    public string Nome { get; set; }
    public string Telefone { get; set; }
}
```

A classe possui um construtor e duas propriedades definidas como do tipo string.

Essa classe pode ser instanciada da seguinte forma:

```c#
public class Program
{
    private static void Main(string[] args)
    {
        var p1 = new Pessoa("Maria", "1198528877");
        Console.ReadLine();
    }
}
```

O problema é bem sutil, mas se por algum motivo ou descuido, o código for refatorado, e a ordem dos parâmetros no construtor for alterada vamos ter problemas.

Suponha que isso aconteceu e que a classe Pessoa foi agora definida assim:

```c#
public class Pessoa
{
    public Pessoa(string telefone, string nome)
    {
        Nome = nome;
        Telefone = telefone;
    }
    public string Nome { get; set; }
    public string Telefone { get; set; }
}
```

Note que a ordem dos parâmetros foi trocada.

A instanciação da classe pode ser feita da mesma forma, e, o compilador não vai reclamar, se tivermos o seguinte código:

```c#
public class Program
{
    private static void Main(string[] args)
    {
        var p1 = new Pessoa("Maria", "1198528877");
        Console.ReadLine();
    }
}
```

Perceba que agora 'Maria' será atribuída à propriedade Telefone e o telefone à propriedade Telefone.

Assim o resultado pode ser uma catástrofe em produção dependendo do tipo de aplicação e do cenário.

### 2- Ferem o princípio DRY

Como o nome diz, os tipos primitivos são primitivos, o que significa que eles não contêm lógica.

O principal problema surge quando você deseja usar esses valores com segurança. Você não tem escolha a não ser realizar algumas verificações como; não nulo, não vazio, etc.

Pode parecer bom nas primeiras vezes que você tem que fazer isso, mas com o tempo o que tende a acontecer é que você duplicará essa lógica em todo o lugar em seu aplicativo.

Isso levará a uma base de código que é muito difícil de manter e que viola diretamente o princípio **Don't Repeat Yourself (DRY)**.

### 3- Levam os métodos a terem uma assinatura difícil de entender

Com certeza você já viu métodos assim:

```c#
Processar(false, true, false, true)
```

Esses tipos de assinaturas de métodos são frágeis e difíceis de entender. Mesmo ao olhar para a definição do método, você não saberá como deve usar todos os parâmetros.

Alguns parâmetros são exclusivos?

Alguns parâmetros substituem o comportamento de outros?

Percebeu como algo que parece ser simples pode levar a problemas nos pequenos detalhes.

## Contornando o problema da obsessão por primitivos

Então qual seria a solução para evitar tais problemas?

A solução para a obsessão primitiva é, de fato, bastante simples.

Você deve aproveitar o sistema tipagem do compilador C# criando um tipo para tudo. Pode parecer um exagero no início, mas, no longo prazo, sempre compensa.

Eu sei... há muito código clichê para criar uma nova classe na sintaxe da linguagem C#, mas sério, é tão longo assim?

Dois minutos, talvez?

Pergunte a si mesmo quanto tempo levará para encontrar e corrigir um bug causado pelos problemas em potencial descritos anteriormente.

Além disso a versão 9 da linguagem C# favorece a escrita de um código mais enxuto e isso pode ser um incentivo para podermos definir os tipos ao invés de usar os tipos primitivos quando isso for pertinente.

Assim aplicando isso à classe **Pessoa** vamos criar os tipos para **Nome** e **Telefone** ao invés de usar primitivos usando a sintaxe do C# 9.0 :

```c#
using System;
using System.Linq;

Pessoa p = new Pessoa(new Nome("Maria"), new Telefone("11-9998-1122"));

public class Nome
{
    public Nome(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentNullException();
        this.Valor = nome;
    }
    public string Valor { get; set; }
}

public class Telefone
{
    public Telefone(string telefone)
    {
        if (telefone.Any(x => Char.IsLetter(x)))
            throw new Exception("Telefone não pode conter letras");
        this.Valor = telefone;
    }
    public string Valor { get; set; }
}

public class Pessoa
{
  public Pessoa(Nome nome, Telefone telefone)
  {
    this.Nome = nome;
    this.Telefone = telefone;
  }
  public Nome Nome { get; set; }
  public Telefone Telefone { get; set; }
}
```

Criar tipos específicos ao invés de usar simplesmente um tipo primitivo trás ainda o benefício de tornar a lógica usada muito mais fácil de ser testada, já que não precisamos inicializar ou simular extensivamente para testar esse tipo de classe.

Mesmo os serviços que usam esses tipos são mais fáceis de testar, pois agora você pode assumir que os objetos são sempre válidos se forem construídos com êxito. Com o tempo, isso reduzirá a **complexidade ciclomática** de seus métodos e, portanto, o caminho do código que você precisa testar.

**Nota**: A **complexidade ciclomática** é uma medida de complexidade de um algoritmo onde é considerado os caminhos independentes que o algoritmo pode tomar. Quanto maior a **complexidade ciclomática** mais difícil de acompanhar o código, de dar manutenção, testar e fazer cobertura total.

# Referências

> [Macoratti](http://www.macoratti.net/21/05/c_primobsess1.htm)
