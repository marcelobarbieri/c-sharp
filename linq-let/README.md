# Utilizando Let no LINQ

O **LINQ** permite realizar consultas em listas de objetos de forma simples e prática.

## LINQ

**LINQ - Language Integrated Query** (Consulta de Linguagem Integrada)

Permite executar consultas sobre listas de objetos assim como é feito no SQL, por exemplo.

```c#
var data = from c in customers select c;
```

A diferença é que a consulta é executada sobre uma lista de objetos ao invés de uma tabela, e com a vantagem da tipagem e compilação.

## LINQ to SQL

Ao utilizar **LINQ** junto ao **Entity Framework**, por exemplo, as **queries** são traduzidas para a linguagem SQL.

Neste caso, por exemplo, caso a execução do **select** seja sobre um **DbSet** do seu **DataContext**, o resultado será traduzido como abaixo.

```c#
var data = from c in context.Customers select c;
```

```sql
SELECT * FROM [Customer]
```

O **LINQ** é extremamente poderoso e podemos compor ele como fazemos com a linguagem SQL, incluindo gerar novos objetos a partir do **select** como mostrado abaixo.

```c#
var data =
    from c in context.Customers
    select new { c.Name, c.Email};
```

Neste caso, é possível notar que o SQL gerado seleciona apenas os campos informados no **select new** do **LINQ** que foi criado. Ele vai sempre acompanhar o **LINQ**, tentando fazer a tradução mais fiel possível.

```sql
SELECT [Name],[Email] FROM [Customer]
```

## Mais exemplos

O **LINQ** também suporte diversos métodos que existem no SQL como **OrderBy**, **Sum**, **GroupBy** dentre outros.

### Order By

O uso do **OrderBy** no **LINQ** é simples. Basta informar a palavra reservada **orderBy** seguida do campo e do tipo de ordenação (**ascending** ou **descending**), como mostrado abaixo.

```c#
var data =
    from c in context.Customer
    orderBy c.Name descending
    select new {
        c.Name,
        c.Email
    };
```

### Group By

O **GroupBy** permite agrupar conjuntos de dados, como, por exemplo, agrupar os pedidos pela quantidade de itens que possuem, conforme mostrado abaixo.

```c#
var groupOrderByItemsQuantity =
    from order in orders
    group order by order.OrderLines.Count into groupByQuantity
    orderby groupByQuantity.Key
    select groupByQuantity;
```

Note que o retorno do **groupBy** é um **KeyValue** sendo **Key** a ordem e **Value** os itens agrupados. Por este motivo utilizamos **orderby groupByQuantity.Key** antes do **select**.

## Utilizando let no LINQ

Todas estas explicações foram para chegar em um recurso relativamente novo no **LINQ**, a possibilidade de criar variáveis durante a criação/ execução da query.

O **LINQ** nos permite utilizar a palavra reservada **let** para armazenar valores como total de itens ou soma de determinados valores. Posteriormente, estas variáveis pode ser utilizadas no **where**, **select** ou mesmo no **groupBy**.

Para exemplificar este uso, vamos criar dois **records**, um para o pedido e outro para o item do pedido, como mostrado abaixo.

```c#
public record Order(string Number, List<OrderLine> OrderLines);
public record OrderLine(string Product, int Quantity, decimal Price);
```

Com a lista criada, pode-se popula-la com alguns dados.
Foi criado o método **GenerateOrderLine** para criar alguns itens do pedido de forma randômica.

```c#
var orders = new List<Order>
{
    new("Order 1 -10 itens", GenerateOrderLines(9)),
    new("Order 2 +10 itens", GenerateOrderLines(12)),
    new("Order 3 +10 itens", GenerateOrderLines(18)),
    new("Order 4 +10 itens", GenerateOrderLines(22))
};

List<OrderLine> GenerateOrderLine(int quantity)
{
    var result = new List<OrderLine>();
    for (var i = 0; i < quantity; i++)
        result.Add(new OrderLine($"Product {i}", i, i));
}
```

Suponha que queira obter todos os pedidos com mais de 10 itens e cujo total seja maior que 100.

Pode ser utilizado o **where** para filtrar os dados, mas não temos o total dos itens do pedido e nem a soma (total do pedido).

Uma opção seria criar as propriedades no objeto **Order**, mas não é o que se deseja.

```c#
var data =
    from order in orders
    let totalItems = order.OrderLine.Count
    let total = order.OrderLines.Sum(x => x.Price)
    where
        totalItems > 10 &&
        total > 100
    select order;
```

No exemplo acima foram criadas duas variáveis, **totalItems** e **total**, para armazenar o total de itens do pedido e o valor total do mesmo, respectivamente.

Estas variáveis ficam disponíveis para uso no **where** ou mesmo no **select**.

```c#
var data =
    from order in orders
    let totalItems = order.OrderLine.Count
    let total = order.OrderLines.Sum(x => x.Price)
    where
        totalItems > 10 &&
        total > 100
    select new {
        order.Number,
        total,
        totalItems
    }
```

O exemplo acima, utilizando as variáveis no **selec**t além do **where** também funcionaria.

Para listar os itens na tela:

```c#
foreach (var item in data)
    Cnsole.WriteLine($"{item.Number} - {item.OrderLines.Sum(x => x.Price)}");;
```

## Conclusão

O **LINQ** é uma ferramente poderosa que permite realizar consultas simples e complexas em listas de objetos que podem ser traduzidas para linguagem SQL.

Isso não significa que tudo deve ser feito nele.

# Referências

[Balta.io](https://balta.io/blog/csharp-linq-let)
