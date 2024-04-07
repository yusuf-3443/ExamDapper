using Domain.Entities;
using Domain.Responses;

namespace Infrastructure.Services.ParentService;

public interface IParentService
{
    Task<Response<List<Parent>>> GetParentsAsync();
    Task<Response<Parent>> GetParentByIdAsync(int id);
    Task<Response<string>> CreateParentAsync(Parent parent);
    Task<Response<string>> UpdateParentAsync(Parent parent);
    Task<Response<bool>> DeleteParentAsync(int id);

}