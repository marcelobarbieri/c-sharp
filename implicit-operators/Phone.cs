namespace ImplicitOperators;

// public class Phone
// {
//     public string CountryCode { get; set; }
//     public string Area { get; set; }
//     public string Number { get; set; }

//     public override string ToString()
//     {
//         return $"+{CountryCode} ({Area}) {Number}";
//     }
// }

public record Phone(string CountryCode, string Area, string Number)
{
    public static implicit operator string(Phone phone) => $"+{phone.CountryCode} ({phone.Area}) {phone.Number}";

    public static implicit operator Phone(string phone)
    {
        var data = phone.Split(" ");
        return new Phone
        {
            CountryCode = data[0],
            Area = data[1],
            Number = data[2]
        };
    }
}