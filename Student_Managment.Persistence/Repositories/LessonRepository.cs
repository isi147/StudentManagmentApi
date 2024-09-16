using Student_Managment.Aplication.Repositories;
using Student_Managment.Domain.Concretes;
using Student_Managment.Persistence.Context;

namespace Student_Managment.Persistence.Repositories;

public class LessonRepository : GenericRepository<Lesson>, ILessonRepository
{
    public LessonRepository(StudentManagmentDbContext context) : base(context)
    {
    }
}
