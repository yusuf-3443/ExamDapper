using Domain.Entities;
using Domain.Responses;

namespace Infrastructure.Services.ClassroomStudentService;

public interface IClassroomStudentService
{
    Task<Response<List<ClassroomStudent>>> GetClassroomStudents();
    Task<Response<ClassroomStudent>> GetClassroomStudentById(int id);
    Task<Response<string>> AddClassroomStudent(ClassroomStudent classroomStudent);
    Task<Response<string>> UpdateClassroomStudent(ClassroomStudent classroomStudent);
    Task<Response<bool>> DeleteClassroomStudent(int id);
}