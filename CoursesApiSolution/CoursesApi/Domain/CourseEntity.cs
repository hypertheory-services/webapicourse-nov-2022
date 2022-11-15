namespace CoursesApi.Domain;

public class CourseEntity
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public int NumberOfDays { get; set; }
    public string Description { get; set; } = string.Empty;
    public bool Retired { get; set; }
}
