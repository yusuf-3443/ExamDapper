using Domain.Entities;
using Domain.Responses;
using Infrastructure.Services.GradeService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("/api/Grades")]
[ApiController]
public class GradeController(IGradeService gradeService):ControllerBase
{
    private readonly IGradeService _gradeService = gradeService;

    [HttpGet]
    public async Task<Response<List<Grade>>> GetGrades()
    {
        return await _gradeService.GetGrades();
    }
     
    [HttpGet("{gradeId:int}")]
    public async Task<Response<Grade>> GetGradeById(int gradeId)
    {
        return await _gradeService.GetGradeById(gradeId);
    }

    [HttpPost]
    public async Task<Response<string>> CreateGrade(Grade grade)
    {
        return await _gradeService.AddGrade(grade);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateGrade(Grade grade)
    {
        return await _gradeService.UpdateGrade(grade);
    }

    [HttpDelete("{gradeId:int}")]
    public async Task<Response<bool>> DeleteGrade(int gradeId)
    {
        return await _gradeService.DeleteGrade(gradeId);
    }
    
}