using ExtensionMethods.Entities;

public static class CourseExtensions
{
    public static CourseCardViewModel ToCard(Course course)
    {
        // Gera um novo ViewModel e retorna

        return new CourseCardViewModel()
        {
            Title = course.Title,
            Summary = course.Summary,
            Url = course.Url,
            Active = course.Active,
            Tags = course.Tags
        };
    }
}