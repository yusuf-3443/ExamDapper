using System.Net;
using Dapper;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.DataContext;

namespace Infrastructure.Services.ExamResultService;

public class ExamResultService : IExamResultService
{
    private readonly DapperContext _context;

    public ExamResultService(DapperContext context)
    {
        _context = context;
    }

    public async Task<Response<List<ExamResult>>> GetExamResults()
    {
        try
        {
            var sql = $"Select * from examresults";
            var result = await _context.Connection().QueryAsync<ExamResult>(sql);
            return new Response<List<ExamResult>>(result.ToList());
        }
        catch (Exception e)
        {
            return new Response<List<ExamResult>>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<ExamResult>> GetExamResultById(int id)
    {
        try
        {
            var sql = $"Select * from examresults where id = {@id}";
            var result = await _context.Connection().QueryFirstOrDefaultAsync<ExamResult>(sql);
            if (result != null) return new Response<ExamResult>(result);
            return new Response<ExamResult>(HttpStatusCode.BadRequest, "Not found");
        }
        catch (Exception e)
        {
            return new Response<ExamResult>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<string>> AddExamResult(ExamResult examResult)
    {
        try
        {
            var sql = $"Insert into examresults(examid,studentid,courseid,marks)" +
                      $"values ({examResult.ExamId},{examResult.StudentId},{examResult.CourseId},'{examResult.Marks}')";
            var result = await _context.Connection().ExecuteAsync(sql);
            if (result > 0) return new Response<string>("Successfully");
            return new Response<string>(HttpStatusCode.BadRequest, "Failed");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<string>> UpdateExamResult(ExamResult examResult)
    {
        try
        {
            var sql = $"Update examresults " +
                      $"set examid = {examResult.ExamId},studentid = {examResult.StudentId},courseid = {examResult.CourseId},marks = '{examResult.Marks}' where id = {examResult.Id}";
            var result = await _context.Connection().ExecuteAsync(sql);
            if (result > 0) return new Response<string>("Successfully");
            return new Response<string>(HttpStatusCode.BadRequest, "Failed");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<bool>> DeleteExamResult(int id)
    {
        try
        {
            var sql = $"Delete from examresults where id = {@id}";
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