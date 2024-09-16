using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Student_Managment.Domain.Concretes;

namespace Student_Managment.Persistence.Configurations;

public class ExamConfiguration : IEntityTypeConfiguration<Exam>
{
    public void Configure(EntityTypeBuilder<Exam> builder)
    {
        builder.Property(x => x.Mark)
            .HasAnnotation("CheckConstraint", "[Number] >= 0 AND [Number] <= 9");

        builder.HasOne(x => x.Lesson)
          .WithOne(x => x.Exam)
          .HasForeignKey<Lesson>(x => x.ExamId);

        // Seed data
        builder.HasData(
             new Exam { Id = 1, StudentId = 1, Mark = 85, ExamDate = new DateTime(2023, 6, 1), CreatedDate = DateTime.Now },
             new Exam { Id = 2, StudentId = 2, Mark = 90, ExamDate = new DateTime(2023, 6, 2), CreatedDate = DateTime.Now }
         );
    }
}
