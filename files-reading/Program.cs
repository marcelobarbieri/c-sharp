// --- le um arquivo inteiro

var data = File.ReadAllText(@"./text-file.txt");
Console.WriteLine(data);
// Lorem ipsum dolor sit amet.
// Lorem, ipsum dolor.
// Lorem ipsum dolor sit.
// 

// --- le um arquivo linha a linha

var lines = File.ReadAllLines(@"./text-file.txt");
foreach (var line1 in lines)
    Console.WriteLine(line1);

// Lorem ipsum dolor sit amet.
// Lorem, ipsum dolor.
// Lorem ipsum dolor sit.

// --- StreamReader

using var file = new StreamReader(@"./text-file.txt");
string? line2;

while ((line2 = file.ReadLine()) != null)
    Console.WriteLine(line2);

file.Close();

// Lorem ipsum dolor sit amet.
// Lorem, ipsum dolor.
// Lorem ipsum dolor sit.