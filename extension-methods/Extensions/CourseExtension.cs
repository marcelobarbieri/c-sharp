using ExtensionMethods.Entities;

namespace ExtensionMethods.Extensions;

public static class CourseExtensions
{
    public static CourseCardViewModel ToCard(this Course course)
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