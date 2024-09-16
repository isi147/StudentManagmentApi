using FluentValidation;
using Student_Managment.Aplication.Dtos;

namespace Student_Managment.WebApi.Validations;

public class CreateExamDtoValidator : AbstractValidator<CreateExamDto>
{
    public CreateExamDtoValidator()
    {
        RuleFor(x => x.ExamDate).NotEmpty().WithMessage("Exam date is required.");
        RuleFor(x => x.LessonId).GreaterThan(0).WithMessage("Lesson ID must be greater than 0.");
        RuleFor(x => x.StudentId).GreaterThan(0).WithMessage("Student ID must be greater than 0.");
    }
}