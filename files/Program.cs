const string filePath = @"C:\DEV\C#\files\meuarquivo.txt";

try
{
    /** 
    * Manipulação de arquivos
    */

    // --- criação

    File.Create(filePath);

    // --- adicionar conteúdo

    // adiciona o texto ao fim do arquivo
    using var file1 = File.AppendText(filePath);
    file1.WriteLine("Teste 1");
    file1.Close();

    // substitui o conteúdo do arquivo com este texto
    using var file2 = File.CreateText(filePath);
    file2.WriteLine("Teste 2");
    file2.Close();

    // ERRADO 
    var data = File.ReadAllText(filePath);
    data += "Meu texto adicional";
    using var file3 = File.CreateText(filePath);
    file3.WriteLine(data); // Substitui o conteúdo do arquivo com este texto
    file3.Close();

    // CORRETO
    using var file4 = File.AppendText(filePath);
    file4.WriteLine("Meu texto adicional"); // Adiciona o texto ao fim do arquivo
    file4.Close();

    // --- copiar

    File.Copy(filePath, @"C:\DEV\C#\files\outro.txt", overwrite: true);

    // --- mover 

    File.Move(filePath, @"C:\DEV\C#\files\novo.txt", overwrite: true);

    // --- substituir
    File.Replace(@"C:\DEV\C#\files\outro.txt", filePath, @"C:\DEV\C#\files\backup.txt");

    // --- excluir
    File.Delete(filePath);

    // --- verificar se existe
    Console.WriteLine(File.Exists(filePath) ? "Existe" : "Não existe");

    // --- ler

    // lê um arquivo inteiro
    var data = File.ReadAllText(filePath);
    Console.WriteLine(data);

    // le um arquivo linha a linha
    var lines = File.ReadAllLines(filePath);
    foreach (var line in lines)
        Console.WriteLine(line);

    // StreamReader

    using var file = new StreamReader(filePath);
    string? line;

    while ((line = file.ReadLine()) != null)
        Console.WriteLine(line);

    file.Close();

    // --- data e hora da última modificação
    var time = File.GetLastAccessTime(filePath);
    Console.WriteLine(time); // 21/03/2022 09:09:58

    // --- atributos
    var attrs = File.GetAttributes(filePath);
    if ((attrs & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
        Console.WriteLine("read-only");
    if ((attrs & FileAttributes.Compressed) == FileAttributes.Compressed)
        Console.WriteLine("compressed");

}
catch (Exception ex)
{
    // capturar exceção
    Console.WriteLine(ex);
}