namespace CSV.Extensions;

public static class StringExtension
{
    public static DateTime ToDateTime(this string value)
    {
        var data = value.Split("-");
        return new DateTime(
            int.Parse(data[0]),
            int.Parse(data[1]),
            int.Parse(data[2])
        );
    }
}