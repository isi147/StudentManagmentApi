using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Student_Managment.Domain.Concretes;

namespace Student_Managment.Persistence.Configurations;

public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.Property(x => x.Code)
            .HasMaxLength(4);

        builder.Property(x => x.Name)
            .HasMaxLength(30);


        // Seed data
        builder.HasData(
            new Lesson { Id = 1, Code = "MAT", Name = "Mathematics", ExamId = 1, CreatedDate = DateTime.Now },
            new Lesson { Id = 2, Code = "PHY", Name = "Physics", ExamId = 2, CreatedDate = DateTime.Now }
        );
    }
}
