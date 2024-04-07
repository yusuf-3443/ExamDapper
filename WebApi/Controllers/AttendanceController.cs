using Domain.Entities;
using Domain.Responses;
using Infrastructure.Services.AttendanceService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("/api/Attendances")]
[ApiController]
public class AttendanceController(IAttendanceService attendanceService):ControllerBase
{
    private readonly IAttendanceService _attendanceService = attendanceService;

    [HttpGet]
    public async Task<Response<List<Attendance>>> GetAttendances()
    {
        return await _attendanceService.GetAttendances();
    }
     
    [HttpGet("{attendanceId:int}")]
    public async Task<Response<Attendance>> GetAttendanceById(int attendanceId)
    {
        return await _attendanceService.GetAttendanceById(attendanceId);
    }

    [HttpPost]
    public async Task<Response<string>> CreateAttendance(Attendance attendance)
    {
        return await _attendanceService.AddAttendance(attendance);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateAttendance(Attendance attendance)
    {
        return await _attendanceService.UpdateAttendance(attendance);
    }

    [HttpDelete("{attendanceId:int}")]
    public async Task<Response<bool>> DeleteAttendance(int attendanceId)
    {
        return await _attendanceService.DeleteAttendance(attendanceId);
    }
    
}