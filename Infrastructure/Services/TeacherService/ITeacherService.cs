using Domain.Entities;
using Domain.Responses;

namespace Infrastructure.Services.TeacherService;

public interface ITeacherService
{
    Task<Response<List<Teacher>>> GetTeachersAsync();
    Task<Response<Teacher>> GetTeacherByIdAsync(int id);
    Task<Response<string>> CreateTeacherAsync(Teacher teacher);
    Task<Response<string>> UpdateTeacherAsync(Teacher teacher);
    Task<Response<bool>> DeleteTeacherAsync(int id);

}