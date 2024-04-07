using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;


[Route("/api/QuerieStudentExamMarks")]
[ApiController]
public class QueryStudentExamMarks(IQueryService queryService) : ControllerBase
{
    private readonly IQueryService _queryService = queryService;
    
    [HttpGet]
    public async Task<List<StudentExamResult>> GetStudentExamResults()
    {
        return await _queryService.GetStudentExamResult();
    }
}