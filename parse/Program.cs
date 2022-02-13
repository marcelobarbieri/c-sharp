using System.Globalization;

// Parse

var valor1 = int.Parse("123");
var valor2 = bool.Parse("true");
var valor3 = DateTime.Parse("01/01/2022");

Console.WriteLine(valor1); // 123
Console.WriteLine(valor2); // True
Console.WriteLine(valor3); // 01/01/2022 00:00:00

// IFormatProvider

var valor4 = DateTime.Parse("28/10/2022");
Console.WriteLine(valor4);

Console.WriteLine(Thread.CurrentThread.CurrentCulture.Name);

var culture2 = new CultureInfo("en-US");
Console.WriteLine(culture2); // pt-BR
var valor5 = DateTime.Parse("10/28/2022", culture2);
Console.WriteLine(valor5);

// NumberStyles

Console.WriteLine(int.Parse("1234", NumberStyles.None)); // 1234
Console.WriteLine(int.Parse("12123,0", NumberStyles.AllowDecimalPoint)); // 12123
Console.WriteLine(int.Parse("123.456", NumberStyles.AllowThousands));  // 12356

// TryParse

var deuCerto1 = int.TryParse("45689", out var result1);
Console.WriteLine(deuCerto1); // True
Console.WriteLine(result1); // 45689

var deuCerto2 = int.TryParse("asdaasd", out var result2);
Console.WriteLine(deuCerto2); // False
Console.WriteLine(result2); // 0

