using Microsoft.EntityFrameworkCore;
using Student_Managment.Aplication;
using Student_Managment.Aplication.Repositories;
using Student_Managment.Persistence.Context;
using Student_Managment.Persistence.Repositories;

namespace Student_Managment.Persistence;
public class UnitOfWork : IUnitOfWork
{
    private readonly StudentManagmentDbContext _context;
    public IStudentRepository Students { get; }
    public IExamRepository Exams { get; }
    public IGroupRepository Groups { get; }
    public ILessonRepository Lessons { get; }

    public UnitOfWork(StudentManagmentDbContext context, IStudentRepository students, IExamRepository exams, IGroupRepository groups, ILessonRepository lessons)
    {
        _context = context;
        Students = students;
        Exams = exams;
        Groups = groups;
        Lessons = lessons;
    }

    public async Task<int> CompleteAsync() 
        => await _context.SaveChangesAsync();


    public void Dispose() 
        => _context.Dispose();

}
