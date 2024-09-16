using Student_Managment.Aplication.Repositories;
using Student_Managment.Domain.Concretes;
using Student_Managment.Persistence.Context;

namespace Student_Managment.Persistence.Repositories;

public class ExamRepository : GenericRepository<Exam>, IExamRepository
{
    public ExamRepository(StudentManagmentDbContext context) : base(context)
    {
    }
}
