namespace Domain.Entities;

public class Parent
{
    public int  Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime Dob { get; set; }
    public string Phone { get; set; }
    public bool Status { get; set; }
}