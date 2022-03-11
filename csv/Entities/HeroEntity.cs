using CSV.Extensions;

namespace CSV.Entities;

public class HeroEntity
{
    public HeroEntity(string name, string phone, DateTime birthDate)
    {
        Name = name;
        Phone = phone;
        BirthDate = birthDate;
    }

    public string Name { get; set; }
    public string Phone { get; set; }
    public DateTime BirthDate { get; set; }

    public static implicit operator string(HeroEntity hero)
        => $"{hero.Name},{hero.Phone},{hero.BirthDate.ToString("yyyy-MM-dd")}";

    public static implicit operator HeroEntity(string line)
    {
        var data = line.Split(",");
        return new HeroEntity(
            data[0],
            data[1],
            data[2].ToDateTime());
    }
}