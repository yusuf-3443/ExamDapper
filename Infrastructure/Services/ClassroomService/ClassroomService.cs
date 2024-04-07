using System.Net;
using Dapper;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.DataContext;
namespace Infrastructure.Services.ClassroomService;

    public class ClassroomService : IClassroomService
{
    private readonly DapperContext _context;

    public ClassroomService(DapperContext context)
    {
        _context = context;
    }

    public async Task<Response<List<Classroom>>> GetClassrooms()
    {
        try
        {

        var sql = $"Select * from Classrooms";
        var result = await _context.Connection().QueryAsync<Classroom>(sql);
        return new Response<List<Classroom>>(result.ToList());
        
        }
        catch (Exception e)
        {
            return new Response<List<Classroom>>(HttpStatusCode.InternalServerError, e.Message);
        }
        }

    public async Task<Response<Classroom>> GetClassroomById(int id)
    {
        try
        {
            var sql = $"Select * from classrooms where id = {@id}";
            var result = await _context.Connection().QueryFirstOrDefaultAsync<Classroom>(sql);
            if (result != null) return new Response<Classroom>(result);
            return new Response<Classroom>(HttpStatusCode.BadRequest, "Not found");
        }
        catch (Exception e)
        {
            return new Response<Classroom>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<string>> AddClassroom(Classroom classroom)
    {
        try
        {
            var sql = $"Insert into classrooms(year,gradeid,status,remarks,teacherid)" +
                      $"values ({classroom.Year},{classroom.GradeId},'{classroom.Status}','{classroom.Remarks}',{classroom.TeacherId})";
            var result = await _context.Connection().ExecuteAsync(sql);
            if (result > 0) return new Response<string>("Successfully");
            return new Response<string>(HttpStatusCode.BadRequest, "Failed");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<string>> UpdateClassroom(Classroom classroom)
    {
        try
        {
            var sql = $"Update classrooms " +
                      $"set year = {classroom.Year},gradeid = {classroom.GradeId},status = '{classroom.Status}',remarks = '{classroom.Remarks}',teacherid = {classroom.TeacherId} where id = {@classroom.Id}";
            var result = await _context.Connection().ExecuteAsync(sql);
            if (result > 0) return new Response<string>("Successfully");
            return new Response<string>(HttpStatusCode.BadRequest, "Failed");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<bool>> DeleteClassroom(int id)
    {
        try
        {
            var sql = $"Delete from classrooms where id = {@id}";
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