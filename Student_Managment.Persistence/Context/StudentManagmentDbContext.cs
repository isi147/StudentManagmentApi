using Microsoft.EntityFrameworkCore;
using Student_Managment.Domain.Commons;
using Student_Managment.Domain.Concretes;
using System.Reflection;

namespace Student_Managment.Persistence.Context;

public class StudentManagmentDbContext : DbContext
{
    public StudentManagmentDbContext(DbContextOptions<StudentManagmentDbContext> options) : base(options) { }

    // Tables
    public DbSet<Exam> Exams { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(StudentManagmentDbContext))!);
        base.OnModelCreating(builder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var datas = ChangeTracker
              .Entries<IBaseEntity>();

        foreach (var data in datas)
        {
            _ = data.State switch
            {
                EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
                _ => DateTime.UtcNow
            };
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
