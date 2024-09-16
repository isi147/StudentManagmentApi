using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;
using Student_Managment.Aplication;
using Student_Managment.Aplication.Repositories;
using Student_Managment.Aplication.Services;
using Student_Managment.Persistence.Context;
using Student_Managment.Persistence.Repositories;
using Student_Managment.Persistence.Services;

namespace Student_Managment.Persistence;

public static class ServiceRegistrations
{
    public static void AddPersistenceServices(this IServiceCollection services, IConfigurationManager configuration)
    {
        services.AddDbContext<StudentManagmentDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("ProdDb"));
        });

        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<ILessonRepository, LessonRepository>();
        services.AddScoped<IGroupRepository, GroupRepository>();
        services.AddScoped<IExamRepository, ExamRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();



        services.AddScoped<IStudentService, StudentService>();
        services.AddScoped<IGroupService, GroupService>();
        services.AddScoped<ILessonService, LessonService>();
        services.AddScoped<IExamService, ExamService>();
    }
}
