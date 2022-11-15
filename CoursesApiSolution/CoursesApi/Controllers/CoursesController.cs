namespace CoursesApi.Controllers;

public class CoursesController : ControllerBase
{
    [HttpGet("/courses")]
    public async  Task<ActionResult> GetCourses()
    {
        return Ok();
    }
}
