﻿namespace Domain.Entities;

public class Classroom
{
    public int Id { get; set; }
    public int Year { get; set; }
    public int GradeId { get; set; }
    public bool Status { get; set; }
    public string Remarks { get; set; }
    public int TeacherId { get; set; }
}