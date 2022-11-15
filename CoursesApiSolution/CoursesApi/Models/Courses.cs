namespace CoursesApi.Models;

public record CoursesResponseModel
{
    public int NumberOfBackendCourses { get; init; }
    public int NumberOfFrontendCourses { get; init; }

}