using System.Net;
using Dapper;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.DataContext;

namespace Infrastructure.Services.ParentService;

public class ParentService : IParentService
{
    private readonly DapperContext _context;

    public ParentService(DapperContext context)
    {
        _context = context;
    }

    public async Task<Response<List<Parent>>> GetParentsAsync()
    {
        try
        {
            var sql = $"Select * from parents";
            var result = await _context.Connection().QueryAsync<Parent>(sql);
            return new Response<List<Parent>>(result.ToList());
        }
        catch (Exception e)
        {
            return new Response<List<Parent>>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<Parent>> GetParentByIdAsync(int id)
    {
        try
        {
            var sql = $"Select * from parents where id = {@id}";
            var result = await _context.Connection().QueryFirstOrDefaultAsync<Parent>(sql);
            if (result != null) return new Response<Parent>(result);
            return new Response<Parent>(HttpStatusCode.BadRequest, "Not found");
        }
        catch (Exception e)
        {
            return new Response<Parent>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<string>> CreateParentAsync(Parent parent)
    {
        try
        {
            var sql = $"Insert into parents(firstname,lastname,email,password,dob,phone,status)" +
                      $"values ('{parent.FirstName}','{parent.LastName}','{parent.Email}','{parent.Password}','{parent.Dob}','{parent.Phone}','{parent.Status}')";
            var result = await _context.Connection().ExecuteAsync(sql);
            if (result > 0) return new Response<string>("Successfully");
            return new Response<string>(HttpStatusCode.BadRequest, "Failed");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<string>> UpdateParentAsync(Parent parent)
    {
        try
        {
            var sql = $"Update parents set " +
                      $"firstname = '{parent.FirstName}',lastname = '{parent.LastName}',email = '{parent.Email}',password = '{parent.Password}',dob = '{parent.Dob}',phone = '{parent.Phone}',status = '{parent.Status}' where id = {parent.Id}";
            var result = await _context.Connection().ExecuteAsync(sql);
            if (result > 0) return new Response<string>("Successfully");
            return new Response<string>(HttpStatusCode.BadRequest, "Failed");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<bool>> DeleteParentAsync(int id)
    {
        try
        {
            var sql = $"Delete from parents where id = {@id}";
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