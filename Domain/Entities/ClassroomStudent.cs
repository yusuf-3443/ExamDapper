using System.Runtime;

namespace Domain.Entities;

public class ClassroomStudent
{
    public int Id { get; set; }
    public int ClassroomId { get; set; }
    public int StudentId { get; set; }
}