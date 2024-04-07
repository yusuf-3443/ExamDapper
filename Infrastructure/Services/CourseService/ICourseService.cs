using Domain.Entities;
using Domain.Responses;

namespace Infrastructure.Services.CourseService;

public interface ICourseService
{
    Task<Response<List<Course>>> GetCourses();
    Task<Response<Course>> GetCourseById(int id);
    Task<Response<string>> AddCourse(Course course);
    Task<Response<string>> UpdateCourse(Course course);
    Task<Response<bool>> DeleteCourse(int id);
}