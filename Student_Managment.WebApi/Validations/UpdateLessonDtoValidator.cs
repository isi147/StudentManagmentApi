using FluentValidation;
using Student_Managment.Aplication.Dtos;

namespace Student_Managment.WebApi.Validations;

public class UpdateLessonDtoValidator : AbstractValidator<UpdateLessonDto>
{
    public UpdateLessonDtoValidator()
    {
        RuleFor(x => x.Code).NotEmpty().WithMessage("Lesson code is required.")
                            .MaximumLength(10).WithMessage("Code must be less than 10 characters.");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Lesson name is required.")
                            .MaximumLength(30).WithMessage("Lesson name must be less than 30 characters.");
    }
}