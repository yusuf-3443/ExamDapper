using System.Net;
using Dapper;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.DataContext;

namespace Infrastructure.Services.ExamSerrvice;

public class ExamService : IExamService
{
    private readonly DapperContext _context;

    public ExamService(DapperContext context)
    {
        _context = context;
    }

    public async Task<Response<List<Exam>>> GetExams()
    {
        try
        {
            var sql = $"Select * from exams";
            var result = await _context.Connection().QueryAsync<Exam>(sql);
            return new Response<List<Exam>>(result.ToList());
        }
        catch (Exception e)
        {
            return new Response<List<Exam>>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<Exam>> GetExamById(int id)
    {
        try
        {
            var sql = $"Select * from exams where id = {@id}";
            var result = await _context.Connection().QueryFirstOrDefaultAsync<Exam>(sql);
            if (result != null) return new Response<Exam>(result);
            return new Response<Exam>(HttpStatusCode.BadRequest, "Not found");
        }
        catch (Exception e)
        {
            return new Response<Exam>(HttpStatusCode.InternalServerError, e.Message);
            
        }
    }

    public async Task<Response<string>> AddExam(Exam exam)
    {
        try
        {
            var sql = $"Insert into exams(examtypeid,name,startdate)" +
                      $"values ({exam.ExamTypeId},'{exam.Name}','{exam.StartDate}')";
            var result = await _context.Connection().ExecuteAsync(sql);
            if (result > 0) return new Response<string>("Successfully");
            return new Response<string>(HttpStatusCode.BadRequest, "Failed");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<string>> UpdateExam(Exam exam)
    {
        try
        {
            var sql = $"Update exams " +
                      $"set examtypeid = {exam.ExamTypeId},name = '{exam.Name}',startdate = '{exam.StartDate}' where id = '{exam.Id}'";
            var result = await _context.Connection().ExecuteAsync(sql);
            if (result > 0) return new Response<string>("Successfully");
            return new Response<string>(HttpStatusCode.BadRequest, "Failed");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<bool>> DeleteExam(int id)
    {
        try
        {
            var sql = $"Delete from exams where id = {@id}";
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