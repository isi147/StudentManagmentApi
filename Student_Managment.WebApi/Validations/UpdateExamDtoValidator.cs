using FluentValidation;
using Student_Managment.Aplication.Dtos;

namespace Student_Managment.WebApi.Validations;

public class UpdateExamDtoValidator : AbstractValidator<UpdateExamDto>
{
    public UpdateExamDtoValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage("ID is required.");
        RuleFor(x => x.Mark).InclusiveBetween(0, 12).WithMessage("Mark must be between 0 and 100.");
    }
}