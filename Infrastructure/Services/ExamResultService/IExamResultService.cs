using Domain.Entities;
using Domain.Responses;

namespace Infrastructure.Services.ExamResultService;

public interface IExamResultService
{
    Task<Response<List<ExamResult>>> GetExamResults();
    Task<Response<ExamResult>> GetExamResultById(int id);
    Task<Response<string>> AddExamResult(ExamResult examResult);
    Task<Response<string>> UpdateExamResult(ExamResult examResult);
    Task<Response<bool>> DeleteExamResult(int id);
}