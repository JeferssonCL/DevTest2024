using Backend.Application.Dtos;
using FluentValidation;

namespace Backend.Application.Validations;

public class CreateVoteValidation : AbstractValidator<CreateVoteDto>
{
    public CreateVoteValidation()
    {
        RuleFor(v => v.OptionId).NotEmpty().WithMessage("Option Id cannot be empty");
        RuleFor(v => v.OptionId).NotNull().WithMessage("Option Id cannot be null");
        RuleFor(v => v.Email).NotEmpty().WithMessage("Option Id cannot be empty").EmailAddress();
    }
}