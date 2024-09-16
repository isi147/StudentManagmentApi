using FluentValidation;
using Student_Managment.Aplication.Dtos;

namespace Student_Managment.WebApi.Validations;

public class UpdateGroupDtoValidator : AbstractValidator<UpdateGroupDto>
{
    public UpdateGroupDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Group name is required.")
                            .MaximumLength(30).WithMessage("Group name must be less than 30 characters.");
        RuleFor(x => x.Number).GreaterThan(0).WithMessage("Group number must be greater than 0.");
    }
}