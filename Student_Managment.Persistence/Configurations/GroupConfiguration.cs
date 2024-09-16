using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Student_Managment.Domain.Concretes;

namespace Student_Managment.Persistence.Configurations;

public class GroupConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.Property(x => x.Number)
                .HasAnnotation("CheckConstraint", "[Number] >= 0 AND [Number] <= 99");

        builder.Property(x => x.Name)
            .HasMaxLength(30);

        // Seed data
        builder.HasData(
              new Group { Id = 1, Name = "Group A", Number = 101, CreatedDate = DateTime.Now },
              new Group { Id = 2, Name = "Group B", Number = 102, CreatedDate = DateTime.Now }
          );

    }
}
