using Student_Managment.Aplication.Repositories;

namespace Student_Managment.Aplication;

public interface IUnitOfWork : IDisposable
{
    IStudentRepository Students { get; }
    IExamRepository Exams { get; }
    IGroupRepository Groups { get; }
    ILessonRepository Lessons { get; }

    Task<int> CompleteAsync();
}
