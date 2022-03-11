namespace ExtensionMethods.Entities;

public class CourseCardViewModel 
{
    public string Title { get; set; }
    public string Summary { get; set; }
    public string Url { get; set; }
    public bool Active { get; set; } = true;
    public string Tags { get; set; }

    public override string ToString()
    {
        return $"Title: {Title} | Summary: {Summary} | Url: {Url} | Active: {Active} | Tags: {Tags}";
    }
}