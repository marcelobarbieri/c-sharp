// --- String ou string

// Cria uma string vazia
// Receberá warning de possível referência nula a partir do .NET 6
string meuTexto;

// Cria uma string informando um valor inicial
string meuTexto = "valor";

// Cria uma string vazia
string meuTexto = string.Empty;

// ERRO
var meuTexto;

// Cria uma string informando um valor inicial
var meuTexto = "valor";

// Cria uma string vazia
var meuTexto = string.Empty;

// Cria uma string (Nula) que permite nulos
string? meuTexto;


// --- Qual a diferença entre String e string?

string meuTexto = "andre";
String umValor = "algum valor";


// --- StringBuilder

// Operador +=

var meuTexto = "Olá mundo";
meuTexto += " aqui vai mais um";
meuTexto += " e aqui mais um pedaço da string";

// StringBuilder

var meuTexto = new StringBuilder();
meuTexto.Append("Olá mundo");
meuTexto.Append(" aqui vai mais um");
meuTexto.Append(" e aqui mais um pedaço da string");

Console.WriteLine(meuTexto.ToString());


// --- Interpolação de Strings

var meuTexto = "Mundo";
var outroTexto = $"Olá {meuTexto}";