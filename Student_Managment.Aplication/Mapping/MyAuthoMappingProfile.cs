using AutoMapper;
using Student_Managment.Aplication.Dtos;
using Student_Managment.Domain.Concretes;

namespace Student_Managment.Aplication;

public class MyAuthoMappingProfile : Profile
{
    public MyAuthoMappingProfile()
    {
        // DTO -> Entity
        CreateMap<CreateGroupDto, Group>();
        CreateMap<UpdateGroupDto, Group>();
        CreateMap<CreateLessonDto, Lesson>();
        CreateMap<UpdateLessonDto, Lesson>();
        CreateMap<CreateStudentDto, Student>();
        CreateMap<UpdateStudentDto, Student>();
        CreateMap<CreateExamDto, Exam>();
        CreateMap<UpdateExamDto, Exam>();

        // Entity -> DTO
        CreateMap<Lesson, CreateLessonDto>();
        CreateMap<Lesson, UpdateLessonDto>();
        CreateMap<Group, CreateGroupDto>();
        CreateMap<Group, UpdateGroupDto>();
        CreateMap<Student, CreateStudentDto>();
        CreateMap<Student, UpdateStudentDto>();
        CreateMap<Exam, CreateExamDto>();
        CreateMap<Exam, UpdateExamDto>();
    }
}
