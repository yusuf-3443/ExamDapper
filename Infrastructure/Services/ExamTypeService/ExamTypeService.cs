using System.Net;
using Dapper;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.DataContext;

namespace Infrastructure.Services.ExamTypeService;

public class ExamTypeService : IExamTypeService
{
    private readonly DapperContext _context;

    public ExamTypeService(DapperContext context)
    {
        _context = context;
    }

    public async Task<Response<List<ExamType>>> GetExamTypes()
    {
        try
        {
            var sql = $"Select * from examtypes";
            var result = await _context.Connection().QueryAsync<ExamType>(sql);
            return new Response<List<ExamType>>(result.ToList());
        }
        catch (Exception e)
        {
            return new Response<List<ExamType>>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<ExamType>> GetExamTypeById(int id)
    {
        try
        {
            var sql = $"Select * from examtypes where id = {@id}";
            var result = await _context.Connection().QueryFirstOrDefaultAsync<ExamType>(sql);
            if (result != null) return new Response<ExamType>(result);
            return new Response<ExamType>(HttpStatusCode.BadRequest, "Not found");
        }
        catch (Exception e)
        {
            return new Response<ExamType>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<string>> AddExamType(ExamType examType)
    {
        try
        {
            var sql = $"Insert into examtypes(name,description)" +
                      $"values ('{examType.Name}','{examType.Description}')";
            var result = await _context.Connection().ExecuteAsync(sql);
            if (result > 0) return new Response<string>("Successfully");
            return new Response<string>(HttpStatusCode.BadRequest, "Failed");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<string>> UpdateExamType(ExamType examType)
    {
        try
        {
            var sql = $"Upade examtypes set " +
                      $"name = '{examType.Name}',description = '{examType.Description}' where id = {examType.Id}";
            var result = await _context.Connection().ExecuteAsync(sql);
            if (result > 0) return new Response<string>("Successfully");
            return new Response<string>(HttpStatusCode.BadRequest, "Failed");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<bool>> DeleteExamType(int id)
    {
        try
        {

        var sql = $"Delete from examtypes where id = {@id}";
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