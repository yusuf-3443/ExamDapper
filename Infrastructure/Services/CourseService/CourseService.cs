using System.Net;
using Dapper;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.DataContext;

namespace Infrastructure.Services.CourseService;

public class CourseService : ICourseService
{
    private readonly DapperContext _context;

    public CourseService(DapperContext context)
    {
        _context = context;
    }

    public async Task<Response<List<Course>>> GetCourses()
    {
        try
        {
            var sql = $"Select * from courses";
            var result = await _context.Connection().QueryAsync<Course>(sql);
            return new Response<List<Course>>(result.ToList());
        }
        catch (Exception e)
        {
            return new Response<List<Course>>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<Course>> GetCourseById(int id)
    {
        try
        {
            var sql = $"Select * from courses where id = {@id}";
            var result = await _context.Connection().QueryFirstOrDefaultAsync<Course>(sql);
            if (result != null) return new Response<Course>(result);
            return new Response<Course>(HttpStatusCode.BadRequest, "Not found");
            
        }
        catch (Exception e)
        {
            return new Response<Course>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<string>> AddCourse(Course course)
    {
        try
        {
            var sql = $"Insert into courses(name,description,gradeid)" +
                      $"values ('{course.Name}','{course.Description}',{course.GradeId})";
            var result = await _context.Connection().ExecuteAsync(sql);
            if (result > 0) return new Response<string>("Successfully");
            return new Response<string>(HttpStatusCode.BadRequest, "Failed");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<string>> UpdateCourse(Course course)
    {
        try
        {
            var sql = $"Update courses " +
                      $"set name = '{course.Name}',description = '{course.Description}',gradeid = {course.GradeId} where id = {course.Id}";
            var result = await _context.Connection().ExecuteAsync(sql);
            if (result > 0) return new Response<string>("Successfully");
            return new Response<string>(HttpStatusCode.BadRequest, "Failed");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<bool>> DeleteCourse(int id)
    {
        try
        {
            var sql = $"Delete from courses where id = {@id}";
            var result = await _context.Connection().ExecuteAsync(sql);
            if (result > 0) return new Response<bool>(true);
            return new Response<bool>(HttpStatusCode.BadRequest, "Failed");
        }
        catch (Exception e)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
        }
    }
}