using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("/api/QuerieStudentParent")]
[ApiController]
public class QueryStudentParentController(IQueryService queryService) : ControllerBase
{
    private readonly IQueryService _queryService = queryService;
    
    [HttpGet]
    public async Task<List<StudentParent>> GetStudentParents()
    {
        return await _queryService.GetStudentParents();
    }
}