using Domain.Entities;
using Domain.Responses;

namespace Infrastructure.Services.ClassroomService;

public interface IClassroomService
{
    Task<Response<List<Classroom>>> GetClassrooms();
    Task<Response<Classroom>> GetClassroomById(int id);
    Task<Response<string>> AddClassroom(Classroom classroom);
    Task<Response<string>> UpdateClassroom(Classroom classroom);
    Task<Response<bool>> DeleteClassroom(int id);
}