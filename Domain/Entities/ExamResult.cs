using System.Runtime;

namespace Domain.Entities;

public class ExamResult
{
    public int Id { get; set; }
    public int ExamId { get; set; }
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public string Marks { get; set; }
}