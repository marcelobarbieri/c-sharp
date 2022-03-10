namespace ExtensionMethods.Entities;

public class Course : Entity
{
    public Course(
        string title,
        string summary,
        string url,
        int duration,
        DateTime create,
        DateTime update,
        bool active,
        bool free,
        bool featured,
        Guid author,
        Guid category,
        string tags
    )
    {
        Title = title;
        Summary = summary;
        Url = url;
        DurationInMinutes = duration;
        CreateDate = create;
        LastUpdateDate = update;
        Active = active;
        Free = free;
        Featured = featured;
        AuthorId = author;
        CategoryId = category;
        Tags = tags;
    }

    public string Title { get; set; }
    public string Summary { get; set; }
    public string Url { get; set; }
    public int DurationInMinutes { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime LastUpdateDate { get; set; } = DateTime.UtcNow;
    public bool Active { get; set; } = true;
    public bool Free { get; set; } = false;
    public bool Featured { get; set; } = false;
    public Guid AuthorId { get; set; }
    public Guid CategoryId { get; set; }
    public string Tags { get; set; }

    
}