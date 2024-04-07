using Domain.Entities;
using Domain.Responses;
using Infrastructure.Services.ExamTypeService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("/api/ExamTypes")]
[ApiController]
public class ExamTypeController(IExamTypeService examTypeService):ControllerBase
{
    private readonly IExamTypeService _examTypeService = examTypeService;

    [HttpGet]
    public async Task<Response<List<ExamType>>> GetExamTypes()
    {
        return await _examTypeService.GetExamTypes();
    }
     
    [HttpGet("{examTypeId:int}")]
    public async Task<Response<ExamType>> GetExamTypeById(int examTypeId)
    {
        return await _examTypeService.GetExamTypeById(examTypeId);
    }

    [HttpPost]
    public async Task<Response<string>> CreateExamType(ExamType examType)
    {
        return await _examTypeService.AddExamType(examType);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateExamType(ExamType examType)
    {
        return await _examTypeService.UpdateExamType(examType);
    }

    [HttpDelete("{examTypeId:int}")]
    public async Task<Response<bool>> DeleteExamType(int examTypeId)
    {
        return await _examTypeService.DeleteExamType(examTypeId);
    }
    
}