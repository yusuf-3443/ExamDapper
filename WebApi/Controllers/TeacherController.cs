using Domain.Entities;
using Domain.Responses;
using Infrastructure.Services.TeacherService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("/api/Teachers")]
[ApiController]
public class TeacherController(ITeacherService teacherService):ControllerBase
{
    private readonly ITeacherService _teacherService = teacherService;

    [HttpGet]
    public async Task<Response<List<Teacher>>> GetTeachersAsync()
    {
        return await _teacherService.GetTeachersAsync();
    }
     
    [HttpGet("{teacherId:int}")]
    public async Task<Response<Teacher>> GetTeacherByIdAsync(int teacherId)
    {
        return await _teacherService.GetTeacherByIdAsync(teacherId);
    }

    [HttpPost]
    public async Task<Response<string>> CreateTeacherAsync(Teacher teacher)
    {
        return await _teacherService.CreateTeacherAsync(teacher);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateTeacherAsync(Teacher teacher)
    {
        return await _teacherService.UpdateTeacherAsync(teacher);
    }

    [HttpDelete("{teacherId:int}")]
    public async Task<Response<bool>> DeleteTeacherAsync(int teacherId)
    {
        return await _teacherService.DeleteTeacherAsync(teacherId);
    }
    
}