using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("/api/Queries")]
[ApiController]
public class QueryStudentAttendanceController(IQueryService queryService) : ControllerBase
{
    private readonly IQueryService _queryService = queryService;
    
    [HttpGet]
    public async Task<List<StudentAttendance>> GetStudentAttendance()
    {
        return await _queryService.GetStudentAttendance();
    }
}
