using Dapper;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.DataContext;

namespace Infrastructure.Services;

public class QueryServices : IQueryService
{
    private readonly DapperContext _context;

    public QueryServices(DapperContext context)
    {
        _context = context;
    }
    public async Task<List<StudentAttendance>> GetStudentAttendance()
    {
        var sql =
            $"select students.firstname as StudentName,attendances.date as Attendance from attendances\njoin students on attendances.studentid = students.id";
        var result = await _context.Connection().QueryAsync<StudentAttendance>(sql);
        return result.ToList();
    }

    public async Task<List<StudentExamResult>> GetStudentExamResult()
    {
        var sql =
            $"select students.firstname as StudentName,examresults.marks as ExamMarks from examresults\njoin students on examresults.studentid = students.id";
        var result = await _context.Connection().QueryAsync<StudentExamResult>(sql);
        return result.ToList();
    }

    public async Task<List<StudentGrades>> GetStudentGrades()
    {
        var sql =
            $"select students.firstname as StudentName,grades.name as GradeName from classroomstudents\njoin students on classroomstudents.studentid = students.id\njoin classrooms on classroomstudents.classroomid = classrooms.id\njoin grades on classrooms.gradeid  =grades.id";
        var result = await _context.Connection().QueryAsync<StudentGrades>(sql);
        return result.ToList();
    }

    public async Task<List<StudentParent>> GetStudentParents()
    {
        var sql =
            $"select parents.firstname as ParentName,students.firstname as StudentName from students\njoin parents on students.parentid = parents.id\ngroup by parents.firstname"; 
        var result = await _context.Connection().QueryAsync<StudentParent>(sql);
        return result.ToList();
    }
}