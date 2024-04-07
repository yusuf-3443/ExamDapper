using Domain.Entities;
using Domain.Responses;
using Infrastructure.Services.ExamResultService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("/api/ExamResults")]
[ApiController]
public class ExamResultController(IExamResultService examResultService):ControllerBase
{
    private readonly IExamResultService _examResultService = examResultService;

    [HttpGet]
    public async Task<Response<List<ExamResult>>> GetExamResults()
    {
        return await _examResultService.GetExamResults();
    }
     
    [HttpGet("{examResultId:int}")]
    public async Task<Response<ExamResult>> GetExamResultById(int examResultId)
    {
        return await _examResultService.GetExamResultById(examResultId);
    }

    [HttpPost]
    public async Task<Response<string>> CreateExamResult(ExamResult examResult)
    {
        return await _examResultService.AddExamResult(examResult);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateExamResult(ExamResult examResult)
    {
        return await _examResultService.UpdateExamResult(examResult);
    }

    [HttpDelete("{examResultId:int}")]
    public async Task<Response<bool>> DeleteExamResult(int examResultId)
    {
        return await _examResultService.DeleteExamResult(examResultId);
    }
    
}