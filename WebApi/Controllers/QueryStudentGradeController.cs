using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("/api/QuerieStudentGrade")]
[ApiController]
public class QueryStudentGradeController(IQueryService queryService) : ControllerBase
{
    private readonly IQueryService _queryService = queryService;
    
    [HttpGet]
    public async Task<List<StudentGrades>> GetStudentGrades()
    {
        return await _queryService.GetStudentGrades();
    }
}