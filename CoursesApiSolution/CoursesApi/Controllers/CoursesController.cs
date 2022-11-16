using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace CoursesApi.Controllers;

//[Route("/courses")]
[ApiController]
public class CoursesController : ControllerBase
{

    private readonly CourseCatalog _catalog;
    private readonly IProvideOfferings _offerings;

    public CoursesController(CourseCatalog catalog, IProvideOfferings offerings)
    {
        _catalog = catalog;
        _offerings = offerings;
    }


    [HttpPost("/backend-courses")]
    public async Task<ActionResult<CourseItemDetailsResponse>> AddBackendCourse([FromBody] CourseCreateRequest request)
    {

        CourseItemDetailsResponse response = await _catalog.AddCourseAsync(request, CategoryType.Backend);

        // If you are doing a POST to a collection
        // return 201 created status code
        // add a location header that says where this new thing lives.
        // add a copy of what they would get if they went to that location header.

        return CreatedAtRoute("course-details", new { id = response.Id }, response);


    }
    [HttpPost("/frontend-courses")]
    public async Task<ActionResult<CourseItemDetailsResponse>> AddFrontendCourse([FromBody] CourseCreateRequest request)
    {
        CourseItemDetailsResponse response = await _catalog.AddCourseAsync(request, CategoryType.Frontend);

        return CreatedAtRoute("course-details", new { id = response.Id }, response);

    }

    //[HttpGet("/courses/{id:int}/offerings")]

    //[ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
    //public async Task<ActionResult> GetOfferingsForCourse(int id)
    //{
    //    // TODO talk about a 404 here.
    //    // check to see if that course exists, if it doesn, return a 404.
    //    var data = await _offerings.GetOfferingsForCourse(id);
    //    return Ok(new { Offerings = data });
    //}

    [HttpGet("/courses/{id:int}", Name ="course-details")]
    public async Task<ActionResult<CourseItemDetailsResponse>> GetCourseById(int id, CancellationToken token)
    {
        CourseItemDetailsResponse? response = await _catalog.GetCourseByIdAsync(id, token);
        return response is CourseItemDetailsResponse data ? Ok(data) : NotFound();
        //if (response == null)
        //{
        //    return NotFound();
        //} else
        //{
        //    return Ok(response);
        //}
    }

    [HttpGet("/courses")]
    public async Task<ActionResult<CoursesResponseModel>> GetCoursesAsync(CancellationToken token)
    {
        CoursesResponseModel response = await _catalog.GetFullCatalogAsync(token);


        return Ok(response);
    }
}
