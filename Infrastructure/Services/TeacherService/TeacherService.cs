using System.Net;
using Dapper;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.DataContext;

namespace Infrastructure.Services.TeacherService;

public class TeacherService : ITeacherService
{
    private readonly DapperContext _context;

    public TeacherService(DapperContext context)
    {
        _context = context;
    }

    public async Task<Response<List<Teacher>>> GetTeachersAsync()
    {
        try
        {
            var sql = $"Select * from teachers";
            var result = await _context.Connection().QueryAsync<Teacher>(sql);
            return new Response<List<Teacher>>(result.ToList());
        }
        catch (Exception e)
        {
            return new Response<List<Teacher>>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<Teacher>> GetTeacherByIdAsync(int id)
    {
        try
        {
            var sql = $"Select * from teachers where id = {@id}";
            var result = await _context.Connection().QueryFirstOrDefaultAsync<Teacher>(sql);
            if (result != null) return new Response<Teacher>(result);
            return new Response<Teacher>(HttpStatusCode.BadRequest, "Failed");
        }
        catch (Exception e)
        {
            return new Response<Teacher>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<string>> CreateTeacherAsync(Teacher teacher)
    {
        try
        {
            var sql = $"Insert into teachers(firstname,lastname,email,password,dob,phone,status)" +
                      $"values ('{teacher.FirstName}','{teacher.LastName}','{teacher.Email}','{teacher.Password}','{teacher.Dob}','{teacher.Phone}','{teacher.Status}')";
            var result = await _context.Connection().ExecuteAsync(sql);
            if (result > 0) return new Response<string>("Successfully");
            return new Response<string>(HttpStatusCode.BadRequest, "Failed");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<string>> UpdateTeacherAsync(Teacher teacher)
    {
        try
        {
            var sql = $"Update teachers set " +
                      $"firstname = '{teacher.FirstName}'.lastname = '{teacher.LastName}',email = '{teacher.Email}',password = '{teacher.Password}',dob = '{teacher.Dob}',phone = '{teacher.Phone}',status = '{teacher.Status}' where id = {teacher.Id}";
            var result = await _context.Connection().ExecuteAsync(sql);
            if (result > 0) return new Response<string>("Successfully");
            return new Response<string>(HttpStatusCode.BadRequest, "Failed");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<bool>> DeleteTeacherAsync(int id)
    {
        try
        {

        var sql = $"Delete from teachers where id = {@id}";
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