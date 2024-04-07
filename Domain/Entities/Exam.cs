namespace Domain.Entities;

public class Exam
{
    public int Id { get; set; }
    public int ExamTypeId { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
}