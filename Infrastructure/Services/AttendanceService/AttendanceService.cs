using System.Net;
using Dapper;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.DataContext;

namespace Infrastructure.Services.AttendanceService;

public class AttendanceService : IAttendanceService
{
    private readonly DapperContext _context;

    public AttendanceService(DapperContext context)
    {
        _context = context;
    }

    public async Task<Response<List<Attendance>>> GetAttendances()
    {
        try
        {

        var sql = $"Select * from attendances";
        var result = await _context.Connection().QueryAsync<Attendance>(sql);
        return new Response<List<Attendance>>(result.ToList());
        
        }
        catch (Exception e)
        {
            return new Response<List<Attendance>>(HttpStatusCode.InternalServerError, e.Message);
        }
        }

    public async Task<Response<Attendance>> GetAttendanceById(int id)
    {
        try
        {
            var sql = $"Select * from attendances where id = {@id}";
            var result = await _context.Connection().QueryFirstOrDefaultAsync<Attendance>(sql);
            if (result != null) return new Response<Attendance>(result);
            return new Response<Attendance>(HttpStatusCode.BadRequest, "Not found");
        }
        catch (Exception e)
        {
            return new Response<Attendance>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<string>> AddAttendance(Attendance attendance)
    {
        try
        {
            var sql = $"Insert into attendances(date,studentid,status,remark)" +
                      $"values ('{attendance.Date}',{attendance.StudentId},'{attendance.Status}','{attendance.Remark}')";
            var result = await _context.Connection().ExecuteAsync(sql);
            if (result > 0) return new Response<string>("Successfully");
            return new Response<string>(HttpStatusCode.BadRequest, "Failed");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<string>> UpdateAttendance(Attendance attendance)
    {
        try
        {
            var sql = $"Update attendances " +
                      $"set date = '{attendance.Date}',studentid = {attendance.StudentId},status = '{attendance.Status}',remark = '{attendance.Remark}' where id = {@attendance.Id}";
            var result = await _context.Connection().ExecuteAsync(sql);
            if (result > 0) return new Response<string>("Successfully");
            return new Response<string>(HttpStatusCode.BadRequest, "Failed");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<bool>> DeleteAttendance(int id)
    {
        try
        {
            var sql = $"Delete from attendances where id = {@id}";
            var result = await _context.Connection().ExecuteAsync(sql);
            if (result > 0) return new Response<bool>(true);
            return new Response<bool>(HttpStatusCode.BadRequest, "Failed");
        }
        catch (Exception e)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
        }
    }
}