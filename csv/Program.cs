using CSV.Entities;

var heroes = new List<HeroEntity>
{
    new("Bruce Wayne", "5599999999996", DateTime.Now.AddYears(-40)),
    new("Bruce Banner", "5599999999997", DateTime.Now.AddYears(-38)),
    new("Peter Parker", "5599999999996", DateTime.Now.AddYears(-18)),
    new("Tony Stark", "5599999999996", DateTime.Now.AddYears(-33)),
};

/**
 * Escrevendo um CSV
 */

heroes.Select(hero => (string)hero);

File.WriteAllLines("heroes.csv", heroes.Select(hero => (string)hero).ToList());

// Bruce Wayne,5599999999996,1982-01-07
// Bruce Banner,5599999999997,1984-01-07
// Peter Parker,5599999999996,2004-01-07
// Tony Stark,5599999999996,1989-01-07

/** 
 * Lendo um CSV
 */

var data = File.ReadLines("heroes.csv");
foreach (var line in data)
{
    HeroEntity hero = line;
    Console.WriteLine(hero.Name);
    Console.WriteLine(hero.Phone);
    Console.WriteLine(hero.BirthDate);
    Console.WriteLine("--");
}
Console.ReadLine();

//Bruce Wayne
//5599999999996
//11/03/1982 00:00:00
//--
//Bruce Banner
//5599999999997
//11/03/1984 00:00:00
//--
//Peter Parker
//5599999999996
//11/03/2004 00:00:00
//--
//Tony Stark
//5599999999996
//11/03/1989 00:00:00
//--



