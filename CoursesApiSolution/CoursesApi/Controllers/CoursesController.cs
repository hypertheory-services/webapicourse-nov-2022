﻿using Microsoft.EntityFrameworkCore;

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
        var response = await _context.Courses.ToListAsync();
        return Ok(response);

        //var response = new CoursesResponseModel { NumberOfBackendCourses = 99, NumberOfFrontendCourses = 12 };
        //return Ok(response);
    }
}
