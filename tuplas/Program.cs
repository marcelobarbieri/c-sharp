// ------------------------------------------------------------
// --- Cria e lê Tuplas
// ------------------------------------------------------------

// new Tuple<T>()

var tupla1 = new Tuple<string, int>("Meu texto", 7);
Console.WriteLine(tupla1.Item1); // Meu texto
Console.WriteLine(tupla1.Item2); // 7

// Tuple.Create

var tupla2 = Tuple.Create<string, int>("Meu texto", 7);
Console.WriteLine(tupla2.Item1); // Meu texto
Console.WriteLine(tupla2.Item2); // 7

// ------------------------------------------------------------
// --- Inferência de tipos
// ------------------------------------------------------------

(string, int) tupla3 = ("Meu texto", 7);
Console.WriteLine(tupla3.Item1); // Meu texto
Console.WriteLine(tupla3.Item2); // 7

var tupla4 = ("Meu texto", 7);
Console.WriteLine(tupla4.Item1); // Meu texto
Console.WriteLine(tupla4.Item2); // 7

// ------------------------------------------------------------
// --- Nomeação dos itens
// ------------------------------------------------------------

(string Primeiro, int Segundo) tupla5 = ("Meu Texto", 7);
Console.WriteLine(tupla5.Item1); // Meu Texto
Console.WriteLine(tupla5.Item2); // 7
Console.WriteLine(tupla5.Primeiro); // Meu Texto
Console.WriteLine(tupla5.Segundo); // 7

// ------------------------------------------------------------
// --- Listas em tuplas
// ------------------------------------------------------------

var tupla6 = (4.5, new List<string>());
tupla6.Item2.Add("Meu Texto");
tupla6.Item2.Add("Mais um");

foreach (var item in tupla6.Item2)
    Console.WriteLine(item); // Meu texto
                             // Mais um

// ------------------------------------------------------------
// --- Tuplas em métodos
// ------------------------------------------------------------

// Parâmetros

SayMyName(("André", "Baltieri")); // André Baltieri

void SayMyName((string FirstName, string LastName) name)
    => Console.WriteLine($"{name.FirstName} {name.LastName}");

// Retorno

var name = WhatsMyName("André", "Baltieri");
Console.WriteLine(name.FirstName); // André
Console.WriteLine(name.LastName); // Baltieri

(string FirstName, string LastName) WhatsMyName(string firstName, string lastName)
    => (firstName, lastName);

// ------------------------------------------------------------
// --- ValueTuple
// ------------------------------------------------------------

var tuple7 = new ValueTuple<string, int>("Meu texto", 7);
Console.WriteLine(tuple7.Item1); // Meu texto
Console.WriteLine(tuple7.Item2); // 7
