using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Student_Managment.Domain.Concretes;

namespace Student_Managment.Persistence.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.Property(x => x.Number)
            .HasAnnotation("CheckConstraint", "[Number] >= 0 AND [Number] <= 99999");

        builder.Property(x => x.Name)
            .HasMaxLength(30);

        builder.Property(x => x.Surname)
            .HasMaxLength(30);

        builder.Property(x => x.MiddleName)
            .HasMaxLength(30);

        // Seed data
        // Seed data
        builder.HasData(
            new Student { Id = 1, Number = 1001, Name = "John", Surname = "Doe", MiddleName = "Edward", CreatedDate = DateTime.Now },
            new Student { Id = 2, Number = 1002, Name = "Jane", Surname = "Smith", MiddleName = "Ann", CreatedDate = DateTime.Now }
        );
    }
}
