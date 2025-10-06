namespace StudentManagement.Application.DTOs;

public class StudentDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Address { get; set; }
    public DateTime? Dob { get; set; }
    public string? Mssv { get; set; }
    public string? Year { get; set; }
    public string? Class { get; set; }
}
