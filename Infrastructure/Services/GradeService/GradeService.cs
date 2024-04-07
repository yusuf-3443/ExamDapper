using System.Net;
using Dapper;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.DataContext;

namespace Infrastructure.Services.GradeService;

public class GradeService : IGradeService
{
    private readonly DapperContext _context;

    public GradeService(DapperContext context)
    {
        _context = context;
    }

    public async Task<Response<List<Grade>>> GetGrades()
    {
        try
        {
            var sql = $"Select * from grades";
            var result = await _context.Connection().QueryAsync<Grade>(sql);
            return new Response<List<Grade>>(result.ToList());
        }
        catch (Exception e)
        {
            return new Response<List<Grade>>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<Grade>> GetGradeById(int id)
    {
        try
        {
            var sql = $"Select * from grades where id = {@id}";
            var result = await _context.Connection().QueryFirstOrDefaultAsync<Grade>(sql);
            if (result != null) return new Response<Grade>(result);
            return new Response<Grade>(HttpStatusCode.BadRequest, "Not found");
        }
        catch (Exception e)
        {
            return new Response<Grade>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<string>> AddGrade(Grade grade)
    {
        try
        {
            var sql = $"Insert into grades(name,description)" +
                      $"values ('{grade.Name}','{grade.Description}')";
            var result = await _context.Connection().ExecuteAsync(sql);
            if (result > 0) return new Response<string>("Successfully");
            return new Response<string>(HttpStatusCode.BadRequest, "Failed");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<string>> UpdateGrade(Grade grade)
    {
        try
        {
            var sql = $"Update grades set " +
                      $"name = '{grade.Name}',description = '{grade.Description}' where id = {grade.Id}";
            var result = await _context.Connection().ExecuteAsync(sql);
            if (result > 0) return new Response<string>("Successfully");
            return new Response<string>(HttpStatusCode.BadRequest, "Failed");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<bool>> DeleteGrade(int id)
    {
        try
        {
            var sql = $"Delete from grades where id = {@id}";
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