using Domain.Entities;
using Domain.Responses;

namespace Infrastructure.Services.ExamTypeService;

public interface IExamTypeService
{
    Task<Response<List<ExamType>>> GetExamTypes();
    Task<Response<ExamType>> GetExamTypeById(int id);
    Task<Response<string>> AddExamType(ExamType examType);
    Task<Response<string>> UpdateExamType(ExamType examType);
    Task<Response<bool>> DeleteExamType(int id);
}