using System.Net;
using Dapper;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.DataContext;

namespace Infrastructure.Services.StudentService;

public class StudentService : IStudentService
{
      private readonly DapperContext _context;

    public StudentService(DapperContext context)
    {
        _context = context;
    }

    public async Task<Response<List<Student>>> GetStudentsAsync()
    {
        try
        {

        var sql = $"Select * from students";
        var result = await _context.Connection().QueryAsync<Student>(sql);
        return new Response<List<Student>>(result.ToList());
        
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response<List<Student>>(HttpStatusCode.InternalServerError, e.Message);
        }
        }

    public async Task<Response<Student>> GetStudentByIdAsync(int id)
    {
        try
        {

        var sql = $"Select * from students where id = {@id}";
        var result = await _context.Connection().QueryFirstOrDefaultAsync<Student>(sql);
        if (result != null) return new Response<Student>(result);
        return new Response<Student>(HttpStatusCode.BadRequest, "Student not found");
        
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response<Student>(HttpStatusCode.InternalServerError, e.Message);
        }
        }

    public async Task<Response<string>> CreateStudentAsync(Student student)
    {
        try
        {

        var sql = $"Insert into students(firstname,lastname,email,password,dob,phone,parentid,status)" +
                  $"values ('{student.FirstName}','{student.LastName}','{student.Email}','{student.Password}','{student.Dob}','{student.Phone}',{student.ParentId},'{student.Status}')";
        var result = await _context.Connection().ExecuteAsync(sql);
        if (result > 0) return new Response<string>("Student successfully added");
        return new Response<string>(HttpStatusCode.BadRequest, "Failed to add student");
        
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
        }

    public async Task<Response<string>> UpdateStudentAsync(Student student)
    {
        try
        {

        var sql = $"Update students set " +
                  $"firstname = '{student.FirstName}',lastname = '{student.LastName}'," +
                  $"email = '{student.Email}',password = '{student.Password}',dob = '{student.Dob}',phone = '{student.Phone}'," +
                  $"parentid = {student.ParentId},status = '{student.Status}' where id = {@student.Id}";
        var result = await _context.Connection().ExecuteAsync(sql);
        if (result > 0) return new Response<string>("Student successfully updated");
        return new Response<string>(HttpStatusCode.BadRequest, "Failed to update student");
        
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
        }

    public async Task<Response<bool>> DeleteStudentAsync(int id)
    {
        try
        {
            var sql = $"Delete from students where id = {@id}";
            var result = await _context.Connection().ExecuteAsync(sql);
            if (result > 0) return new Response<bool>(true);
            return new Response<bool>(HttpStatusCode.BadRequest, "Failed to delete student");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
        }
    }
}