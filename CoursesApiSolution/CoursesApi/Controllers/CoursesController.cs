namespace CoursesApi.Controllers;

public class CoursesController : ControllerBase
{

    private readonly CoursesDataContext _context;

    public CoursesController(CoursesDataContext context)
    {
        _context = context;
    }

    [HttpGet("/courses")]
    public async  Task<ActionResult> GetCoursesAsync()
    {
        return Ok();
    }
}
