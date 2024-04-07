using Domain.Entities;
using Domain.Responses;
using Infrastructure.Services.ClassroomStudentService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("/api/ClassroomStudents")]
[ApiController]
public class ClassroomStudentController(IClassroomStudentService classroomStudentService):ControllerBase
{
    private readonly IClassroomStudentService _classroomStudentService = classroomStudentService;

    [HttpGet]
    public async Task<Response<List<ClassroomStudent>>> GetClassroomStudents()
    {
        return await _classroomStudentService.GetClassroomStudents();
    }
     
    [HttpGet("{classroomStudentId:int}")]
    public async Task<Response<ClassroomStudent>> GetClassroomStudentById(int classroomStudentId)
    {
        return await _classroomStudentService.GetClassroomStudentById(classroomStudentId);
    }

    [HttpPost]
    public async Task<Response<string>> CreateClassroomStudent(ClassroomStudent classroomStudent)
    {
        return await _classroomStudentService.AddClassroomStudent(classroomStudent);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateClassroomStudent(ClassroomStudent classroomStudent)
    {
        return await _classroomStudentService.UpdateClassroomStudent(classroomStudent);
    }

    [HttpDelete("{classroomStudentId:int}")]
    public async Task<Response<bool>> DeleteClassroomStudent(int classroomStudentId)
    {
        return await _classroomStudentService.DeleteClassroomStudent(classroomStudentId);
    }
    
}