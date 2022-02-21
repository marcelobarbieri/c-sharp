using Operadores;

// ---------------------------------------------------
// --- Operador IS
// ---------------------------------------------------

// --- Tipos primitivos

var someText = "This is a string";

// retorna bool
// var result = someText.GetType() == typeof(string);
var result = someText is string;
Console.WriteLine(result); // True

// --- Tipos complexos

var d = new CNPJ();
if (d is Documento)
    Console.WriteLine("d é um documento"); // d é um documento

// --- Comparação de nulos

var student = new Object();
if (student is null)
    Console.WriteLine("Nulo");
if (student is not null)
    Console.WriteLine("Não Nulo"); // <<<

// ---------------------------------------------------
// --- Operador AS
// ---------------------------------------------------    

var documento = new Documento();
var cpf = documento as CPF;
Console.WriteLine(cpf is CPF); // False
Console.WriteLine(cpf is null); // True
Console.WriteLine(documento is Documento); // True
