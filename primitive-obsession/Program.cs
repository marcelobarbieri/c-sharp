// --- Problema

// var p1 = new Pessoa("Maria", "1198528877");
// var p2 = new Pessoa("1198528877", "Maria");

// public class Pessoa
// {
//     public Pessoa(string nome, string telefone)
//     {
//         Nome = nome;
//         Telefone = telefone;
//     }
//     public string Nome { get; set; }
//     public string Telefone { get; set; }
// }

// --- Solução

using System;
using System.Linq;

Pessoa p = new Pessoa(new Nome("Maria"), new Telefone("11-9998-1122"));
Console.WriteLine(p.ToString()); // Nome: Maria - Telefone: 11-9998-1122

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

    public override string ToString()
    {
        return $"Nome: {Nome.Valor} - Telefone: {Telefone.Valor}";
    }
}

