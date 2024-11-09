using Backend.Application.Dtos;
using FluentValidation;

namespace Backend.Application.Validations;

public class CreatePoolValidation : AbstractValidator<CreatePollDto>
{
    public CreatePoolValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .Matches("^[a-zA-Z0-9 ]*$").WithMessage("Name must be alphanumeric");
        RuleFor(x => x.Options)
            .NotNull().WithMessage("Options is required")
            .Must(o => o != null && o.Count >= 2).WithMessage("Poll must have at least two options");    
    }
}