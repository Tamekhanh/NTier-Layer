using StudentManagement.Application.DTOs;

namespace StudentManagement.Application.Interfaces;

public interface IStudentService
{
    Task<List<StudentDto>> GetAllAsync();
    Task<StudentDto?> GetByIdAsync(int id);
    Task AddAsync(StudentDto student);
    Task UpdateAsync(StudentDto student);
    Task DeleteAsync(int id);
}
