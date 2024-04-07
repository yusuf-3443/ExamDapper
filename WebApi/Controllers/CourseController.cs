using Domain.Entities;
using Domain.Responses;
using Infrastructure.Services.CourseService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("/api/Courses")]
[ApiController]
public class CourseController(ICourseService courseService):ControllerBase
{
    private readonly ICourseService _courseService = courseService;

    [HttpGet]
    public async Task<Response<List<Course>>> GetCourses()
    {
        return await _courseService.GetCourses();
    }
     
    [HttpGet("{courseId:int}")]
    public async Task<Response<Course>> GetCourseById(int courseId)
    {
        return await _courseService.GetCourseById(courseId);
    }

    [HttpPost]
    public async Task<Response<string>> CreateCourse(Course course)
    {
        return await _courseService.AddCourse(course);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateCourse(Course course)
    {
        return await _courseService.UpdateCourse(course);
    }

    [HttpDelete("{courseId:int}")]
    public async Task<Response<bool>> DeleteCourse(int courseId)
    {
        return await _courseService.DeleteCourse(courseId);
    }
    
}