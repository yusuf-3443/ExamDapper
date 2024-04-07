using Domain.Entities;
using Domain.Responses;
using Infrastructure.Services.ParentService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("/api/Parents")]
[ApiController]
public class ParentController(IParentService parentService):ControllerBase
{
    private readonly IParentService _parentService = parentService;

    [HttpGet]
    public async Task<Response<List<Parent>>> GetParentsAsync()
    {
        return await _parentService.GetParentsAsync();
    }
     
    [HttpGet("{parentId:int}")]
    public async Task<Response<Parent>> GetParentByIdAsync(int parentId)
    {
        return await _parentService.GetParentByIdAsync(parentId);
    }

    [HttpPost]
    public async Task<Response<string>> CreateParentAsync(Parent parent)
    {
        return await _parentService.CreateParentAsync(parent);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateParentAsync(Parent parent)
    {
        return await _parentService.UpdateParentAsync(parent);
    }

    [HttpDelete("{parentId:int}")]
    public async Task<Response<bool>> DeleteParentAsync(int parentId)
    {
        return await _parentService.DeleteParentAsync(parentId);
    }
    
}