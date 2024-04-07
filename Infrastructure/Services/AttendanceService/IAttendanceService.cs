using Domain.Entities;
using Domain.Responses;

namespace Infrastructure.Services.AttendanceService;

public interface IAttendanceService
{
    Task<Response<List<Attendance>>> GetAttendances();
    Task<Response<Attendance>> GetAttendanceById(int id);
    Task<Response<string>> AddAttendance(Attendance attendance);
    Task<Response<string>> UpdateAttendance(Attendance attendance);
    Task<Response<bool>> DeleteAttendance(int id);
}