using StudentManagement.Application.DTOs;
using StudentManagement.Application.Interfaces;
using StudentManagement.Domain.Entities;
using StudentManagement.Infrastructure.Repositories;

namespace StudentManagement.Application.Services;

public class StudentService : IStudentService
{
    private readonly StudentRepository _repo;

    public StudentService(StudentRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<StudentDto>> GetAllAsync()
    {
        var students = await _repo.GetAllAsync();
        return students.Select(s => new StudentDto
        {
            Id = s.Id,
            Name = s.Name,
            Address = s.Address,
            Dob = s.Dob,
            Mssv = s.Mssv,
            Year = s.Year,
            Class = s.Class
        }).ToList();
    }

    public async Task<StudentDto?> GetByIdAsync(int id)
    {
        var student = await _repo.GetByIdAsync(id);
        return student == null ? null : new StudentDto
        {
            Id = student.Id,
            Name = student.Name,
            Address = student.Address,
            Dob = student.Dob,
            Mssv = student.Mssv,
            Year = student.Year,
            Class = student.Class
        };
    }

    public async Task AddAsync(StudentDto dto)
    {
        var student = new Student
        {
            Name = dto.Name,
            Address = dto.Address,
            Dob = dto.Dob,
            Mssv = dto.Mssv,
            Year = dto.Year,
            Class = dto.Class
        };
        await _repo.AddAsync(student);
    }

    public async Task UpdateAsync(StudentDto dto)
    {
        var student = new Student
        {
            Id = dto.Id,
            Name = dto.Name,
            Address = dto.Address,
            Dob = dto.Dob,
            Mssv = dto.Mssv,
            Year = dto.Year,
            Class = dto.Class
        };
        await _repo.UpdateAsync(student);
    }

    public async Task DeleteAsync(int id) => await _repo.DeleteAsync(id);
}
