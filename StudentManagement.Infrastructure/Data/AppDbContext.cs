using Microsoft.EntityFrameworkCore;
using StudentManagement.Domain.Entities;

namespace StudentManagement.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<Student> Student { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("Student");
            entity.HasKey(s => s.Id);

            entity.Property(s => s.Name).IsRequired().HasMaxLength(50);
            entity.Property(s => s.Address).HasMaxLength(50);
            entity.Property(s => s.Mssv).HasMaxLength(10);
            entity.Property(s => s.Year).HasMaxLength(4);
            entity.Property(s => s.Class).HasMaxLength(8);
        });
    }
}
