using Domain.Entities;

namespace Infrastructure.Services;

public interface IQueryService
{
    Task<List<StudentAttendance>> GetStudentAttendance();
    Task<List<StudentExamResult>> GetStudentExamResult();
    Task<List<StudentGrades>> GetStudentGrades();
    Task<List<StudentParent>> GetStudentParents();
}