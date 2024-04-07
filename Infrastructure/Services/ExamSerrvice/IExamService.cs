using Domain.Entities;
using Domain.Responses;

namespace Infrastructure.Services.ExamSerrvice;

public interface IExamService
{
    Task<Response<List<Exam>>> GetExams();
    Task<Response<Exam>> GetExamById(int id);
    Task<Response<string>> AddExam(Exam exam);
    Task<Response<string>> UpdateExam(Exam exam);
    Task<Response<bool>> DeleteExam(int id);
}