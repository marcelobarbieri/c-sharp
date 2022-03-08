using LetExample;

List<OrderLine> GenerateOrderLines(int quantity)
{
    var result = new List<OrderLine>();
    for (var i = 0; i < quantity; i++)
        result.Add(new OrderLine($"Product {i}", i, i));
    return result;
}

var orders = new List<Order>
{
    new("Order 1 -10 itens", GenerateOrderLines(9)),
    new("Order 2 +10 itens", GenerateOrderLines(12)),
    new("Order 3 +10 itens", GenerateOrderLines(18)),
    new("Order 4 +10 itens", GenerateOrderLines(22))
};

// -----------------------------------------------------------------------------------------------

// todos os pedidos com mais de 10 itens e total maior que 100

var data1 =
    from order in orders
    let totalItems = order.OrderLines.Count
    let total = order.OrderLines.Sum(x => x.Price)
    where
        totalItems > 10 &&
        total > 100
    select order;

Console.Clear();

foreach (var item in data1) {
    Console.WriteLine($"Order {item.Number}");
    foreach(var line in item.OrderLines) {
        Console.WriteLine($"Order Line - Product: {line.Product}, Quantity: {line.Quantity}, Price: {line.Price}");
    }
}

Console.ReadLine();

//Order Order 3 +10 itens
//Order Line - Product: Product 0, Quantity: 0, Price: 0
//Order Line - Product: Product 1, Quantity: 1, Price: 1
//Order Line - Product: Product 2, Quantity: 2, Price: 2
//Order Line - Product: Product 3, Quantity: 3, Price: 3
//Order Line - Product: Product 4, Quantity: 4, Price: 4
//Order Line - Product: Product 5, Quantity: 5, Price: 5
//Order Line - Product: Product 6, Quantity: 6, Price: 6
//Order Line - Product: Product 7, Quantity: 7, Price: 7
//Order Line - Product: Product 8, Quantity: 8, Price: 8
//Order Line - Product: Product 9, Quantity: 9, Price: 9
//Order Line - Product: Product 10, Quantity: 10, Price: 10
//Order Line - Product: Product 11, Quantity: 11, Price: 11
//Order Line - Product: Product 12, Quantity: 12, Price: 12
//Order Line - Product: Product 13, Quantity: 13, Price: 13
//Order Line - Product: Product 14, Quantity: 14, Price: 14
//Order Line - Product: Product 15, Quantity: 15, Price: 15
//Order Line - Product: Product 16, Quantity: 16, Price: 16
//Order Line - Product: Product 17, Quantity: 17, Price: 17
//Order Order 4 +10 itens
//Order Line - Product: Product 0, Quantity: 0, Price: 0
//Order Line - Product: Product 1, Quantity: 1, Price: 1
//Order Line - Product: Product 2, Quantity: 2, Price: 2
//Order Line - Product: Product 3, Quantity: 3, Price: 3
//Order Line - Product: Product 4, Quantity: 4, Price: 4
//Order Line - Product: Product 5, Quantity: 5, Price: 5
//Order Line - Product: Product 6, Quantity: 6, Price: 6
//Order Line - Product: Product 7, Quantity: 7, Price: 7
//Order Line - Product: Product 8, Quantity: 8, Price: 8
//Order Line - Product: Product 9, Quantity: 9, Price: 9
//Order Line - Product: Product 10, Quantity: 10, Price: 10
//Order Line - Product: Product 11, Quantity: 11, Price: 11
//Order Line - Product: Product 12, Quantity: 12, Price: 12
//Order Line - Product: Product 13, Quantity: 13, Price: 13
//Order Line - Product: Product 14, Quantity: 14, Price: 14
//Order Line - Product: Product 15, Quantity: 15, Price: 15
//Order Line - Product: Product 16, Quantity: 16, Price: 16
//Order Line - Product: Product 17, Quantity: 17, Price: 17
//Order Line - Product: Product 18, Quantity: 18, Price: 18
//Order Line - Product: Product 19, Quantity: 19, Price: 19
//Order Line - Product: Product 20, Quantity: 20, Price: 20
//Order Line - Product: Product 21, Quantity: 21, Price: 21

Console.Clear();

foreach (var item in data1)
    Console.WriteLine($"{item.Number} - {item.OrderLines.Sum(x => x.Price)}");

//Order 3 + 10 itens - 153
//Order 4 + 10 itens - 231

Console.ReadLine();

// -----------------------------------------------------------------------------------------------

// utilização do let para armazenar o total de itens do pedido e o valor total do pedido

var data2 =
    from order in orders
    let totalItems = order.OrderLines.Count
    let total = order.OrderLines.Sum(x => x.Price)
    where
        totalItems > 10 &&
        total > 100
    select new
    {
        order.Number,
        total,
        totalItems
    };

Console.Clear();

foreach (var item in data2)
{
    Console.WriteLine($"Order: {item.Number}, Total: {item.total}, Itens: {item.totalItems}");
}

Console.ReadLine();

//Order: Order 3 + 10 itens, Total: 153, Itens: 18
//Order: Order 4 + 10 itens, Total: 231, Itens: 22

