using Domain.Entities;
using Domain.Responses;
using Infrastructure.Services.ClassroomService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("/api/Classrooms")]
[ApiController]
public class ClassroomController(IClassroomService classroomService):ControllerBase
{
    private readonly IClassroomService _classroomService = classroomService;

    [HttpGet]
    public async Task<Response<List<Classroom>>> GetClassrooms()
    {
        return await _classroomService.GetClassrooms();
    }
     
    [HttpGet("{classroomId:int}")]
    public async Task<Response<Classroom>> GetClassroomById(int classroomId)
    {
        return await _classroomService.GetClassroomById(classroomId);
    }

    [HttpPost]
    public async Task<Response<string>> CreateClassroom(Classroom classroom)
    {
        return await _classroomService.AddClassroom(classroom);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateClassroom(Classroom classroom)
    {
        return await _classroomService.UpdateClassroom(classroom);
    }

    [HttpDelete("{classroomId:int}")]
    public async Task<Response<bool>> DeleteClassroom(int classroomId)
    {
        return await _classroomService.DeleteClassroom(classroomId);
    }
    
}