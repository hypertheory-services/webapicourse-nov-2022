namespace ApiBasics.Controllers;

public class DemoController : ControllerBase
{

    // The Uri and route parameters, query strings etc.
    // - Query String
    // "Collections"
    // GET /employees?department=SALES

    [HttpGet("/employees")]
    public ActionResult GetEmployees([FromQuery] string department = "All")
    {
        return Ok($"{department} employees!");
    }
    // "Documents"

    [HttpGet("/employees/{id:int}")]
    public ActionResult GetEmployee(int id)
    {
        return Ok($"Getting employee {id}");
    }

    [HttpGet("/employees/{id:int}/manager")]
    public ActionResult GetEmployeeManager(int id) {
        return Ok("Michael");
    }
    // GET /employees/bob-smith (Subordinate Resource)


    // GET /department/{id}/employees
    // GET /department/sales/employees


    // The headers (rare, but useful)

    [HttpGet("/whoami")]
    public ActionResult GetUserAgentString([FromHeader(Name ="User-Agent")] string userAgent)
    {
        return Ok("You are running " + userAgent);
    }

    // An entity
}

