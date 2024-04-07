using Domain.Entities;
using Domain.Responses;
using Infrastructure.Services.ExamSerrvice;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("/api/Exams")]
[ApiController]
public class ExamController(IExamService examService):ControllerBase
{
    private readonly IExamService _examService = examService;

    [HttpGet]
    public async Task<Response<List<Exam>>> GetExams()
    {
        return await _examService.GetExams();
    }
     
    [HttpGet("{examId:int}")]
    public async Task<Response<Exam>> GetExamById(int examId)
    {
        return await _examService.GetExamById(examId);
    }

    [HttpPost]
    public async Task<Response<string>> CreateExam(Exam exam)
    {
        return await _examService.AddExam(exam);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateExam(Exam exam)
    {
        return await _examService.UpdateExam(exam);
    }

    [HttpDelete("{examId:int}")]
    public async Task<Response<bool>> DeleteExam(int examId)
    {
        return await _examService.DeleteExam(examId);
    }
    
}