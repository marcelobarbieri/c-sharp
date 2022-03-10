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
courses.Select(x.ToCard());


foreach (var item in courses)
{
    Console.WriteLine(item);
}
Console.ReadLine();
