using System.Net;
using Dapper;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.DataContext;

namespace Infrastructure.Services.ClassroomStudentService;

public class ClassroomStudentService : IClassroomStudentService
{
    private readonly DapperContext _context;

    public ClassroomStudentService(DapperContext context)
    {
        _context = context;
    }

    public async Task<Response<List<ClassroomStudent>>> GetClassroomStudents()
    {
        try
        {
            var sql = $"Select * from classroomstudents";
            var result = await _context.Connection().QueryAsync<ClassroomStudent>(sql);
            return new Response<List<ClassroomStudent>>(result.ToList());
        }
        catch (Exception e)
        {
            return new Response<List<ClassroomStudent>>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<ClassroomStudent>> GetClassroomStudentById(int id)
    {
        try
        {
            var sql = $"Select * from classroomstudents where id = {@id}";
            var result = await _context.Connection().QueryFirstOrDefaultAsync<ClassroomStudent>(sql);
            if (result != null) return new Response<ClassroomStudent>(result);
            return new Response<ClassroomStudent>(HttpStatusCode.BadRequest, "Not found");
        }
        catch (Exception e)
        {
            return new Response<ClassroomStudent>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<string>> AddClassroomStudent(ClassroomStudent classroomStudent)
    {
        try
        {
            var sql = $"Insert into classroomstudents(classroomid,studentid)" +
                      $"values ({classroomStudent.ClassroomId},{classroomStudent.StudentId})";
            var result = await _context.Connection().ExecuteAsync(sql);
            if (result > 0) return new Response<string>("Successfully");
            return new Response<string>(HttpStatusCode.BadRequest, "Failed");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<string>> UpdateClassroomStudent(ClassroomStudent classroomStudent)
    {
        try
        {
            var sql = $"Update classroomstudents " +
                      $"set classroomid = {classroomStudent.ClassroomId},studentid = {classroomStudent.StudentId} where id = {classroomStudent.Id}";
            var result = await _context.Connection().ExecuteAsync(sql);
            if (result > 0) return new Response<string>("Successfully");
            return new Response<string>(HttpStatusCode.BadRequest, "Failed");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<bool>> DeleteClassroomStudent(int id)
    {
        try
        {
            var sql = $"Delete from classroomstudents where id = {@id}";
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