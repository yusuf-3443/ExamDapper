using Domain.Entities;
using Domain.Responses;

namespace Infrastructure.Services.GradeService;

public interface IGradeService
{
    Task<Response<List<Grade>>> GetGrades();
    Task<Response<Grade>> GetGradeById(int id);
    Task<Response<string>> AddGrade(Grade grade);
    Task<Response<string>> UpdateGrade(Grade grade);
    Task<Response<bool>> DeleteGrade(int id);
}