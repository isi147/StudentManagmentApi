using FluentValidation;
using Student_Managment.Aplication.Dtos;

namespace Student_Managment.WebApi.Validations;
public class CreateStudentDtoValidator : AbstractValidator<CreateStudentDto>
{
    public CreateStudentDtoValidator()
    {
        RuleFor(x => x.Number).GreaterThan(0).WithMessage("Student number must be greater than 0.");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
        RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname is required.");
        RuleFor(x => x.MiddleName).NotEmpty().WithMessage("Middle name is required.");
    }
}