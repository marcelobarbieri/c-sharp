using ExtensionMethods.Entities;
using ExtensionMethods.Extensions;

/**
 * Datetime
 */

var minhaData = "2022-01-10";
var data = minhaData.ToDateTime();

Console.WriteLine(data); // 10/01/2022 00:00:00
Console.ReadLine();

/**
 * Class
 */

var courses = new List<Course>
{
    new("Titulo A","Sumario A","Url A",10,DateTime.Now,DateTime.Now,true,true,true,Guid.NewGuid(),Guid.NewGuid(),"Tags A"),
    new("Titulo B","Sumario B","Url B",20,DateTime.Now,DateTime.Now,true,true,true,Guid.NewGuid(),Guid.NewGuid(),"Tags B"),
    new("Titulo C","Sumario C","Url C",30,DateTime.Now,DateTime.Now,true,true,true,Guid.NewGuid(),Guid.NewGuid(),"Tags C"),
    new("Titulo D","Sumario D","Url D",40,DateTime.Now,DateTime.Now,true,true,true,Guid.NewGuid(),Guid.NewGuid(),"Tags D"),
    new("Titulo E","Sumario E","Url E",50,DateTime.Now,DateTime.Now,true,true,true,Guid.NewGuid(),Guid.NewGuid(),"Tags E"),
};

foreach (var item in courses.Select(x => x.ToCard()))
{
    Console.WriteLine(item.ToString());

    //Title: Titulo A | Summary: Sumario A | Url: Url A | Active: True | Tags: Tags A
    //Title: Titulo B | Summary: Sumario B | Url: Url B | Active: True | Tags: Tags B
    //Title: Titulo C | Summary: Sumario C | Url: Url C | Active: True | Tags: Tags C
    //Title: Titulo D | Summary: Sumario D | Url: Url D | Active: True | Tags: Tags D
    //Title: Titulo E | Summary: Sumario E | Url: Url E | Active: True | Tags: Tags E
}
Console.ReadLine();

