using StudentManagement.Domain.Entities;
using StudentManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace StudentManagement.Infrastructure.Repositories;

public class StudentRepository
{
    private readonly AppDbContext _context;

    public StudentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Student>> GetAllAsync() => await _context.Student.ToListAsync();

    public async Task<Student?> GetByIdAsync(int id) => await _context.Student.FindAsync(id);

    public async Task AddAsync(Student student)
    {
        _context.Student.Add(student);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Student student)
    {
        _context.Student.Update(student);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var student = await _context.Student.FindAsync(id);
        if (student != null)
        {
            _context.Student.Remove(student);
            await _context.SaveChangesAsync();
        }
    }
}
