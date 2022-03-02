using System.Text;

// --- String ou string

// Cria uma string vazia
// Receberá warning de possível referência nula a partir do .NET 6

string meuTexto1;
meuTexto1 = "";
Console.WriteLine(meuTexto1);

// Cria uma string informando um valor inicial
string meuTexto2 = "valor";
Console.WriteLine(meuTexto2);

// Cria uma string vazia
string meuTexto3 = string.Empty;

// ERRO
// var meuTexto4;

// Cria uma string informando um valor inicial
var meuTexto5 = "valor";
Console.WriteLine(meuTexto5);

// Cria uma string vazia
var meuTexto6 = string.Empty;

// Cria uma string (Nula) que permite nulos
string? meuTexto7;
meuTexto7 = null;
if (meuTexto7 != null)
    Console.WriteLine(meuTexto7);

// --- Qual a diferença entre String e string?

string meuTexto8 = "andre";
String umValor = "algum valor";

Console.WriteLine(meuTexto8);
Console.WriteLine(umValor);


// --- StringBuilder

// Operador +=

var meuTexto9 = "Olá mundo";
meuTexto9 += " aqui vai mais um";
meuTexto9 += " e aqui mais um pedaço da string";

// StringBuilder

var meuTexto10 = new StringBuilder();
meuTexto10.Append("Olá mundo");
meuTexto10.Append(" aqui vai mais um");
meuTexto10.Append(" e aqui mais um pedaço da string");

Console.WriteLine(meuTexto10.ToString());


// --- Interpolação de Strings

var meuTexto11 = "Mundo";
var outroTexto = $"Olá {meuTexto11}";