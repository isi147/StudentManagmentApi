using FluentValidation;
using Student_Managment.Aplication.Dtos;

namespace Student_Managment.WebApi.Validations;
public class CreateLessonDtoValidator : AbstractValidator<CreateLessonDto>
{
    public CreateLessonDtoValidator()
    {
        RuleFor(x => x.Code).NotEmpty().WithMessage("Lesson code is required.")
                            .MaximumLength(4).WithMessage("Code must be less than 10 characters.");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Lesson name is required.")
                            .MaximumLength(30).WithMessage("Lesson name must be less than 30 characters.");
        RuleFor(x => x.GroupId).GreaterThan(0).WithMessage("Group ID must be greater than 0.");
    }
}