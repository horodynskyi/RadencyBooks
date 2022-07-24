using FluentValidation;
using RadencyBooks.Application.Dtos;

namespace RadencyBooks.Application.Validators;

public class ReviewDtoValidator:AbstractValidator<ReviewDto>
{
    public ReviewDtoValidator()
    {
        RuleFor(x => x.Message)
            .NotEmpty()
            .WithMessage("Message is empty or null")
            .NotNull()
            .WithMessage("Message is empty or null");
        RuleFor(x => x.Reviewer)
            .NotEmpty()
            .WithMessage("Reviewer is empty or null")
            .NotNull()
            .WithMessage("Reviewer is empty or null");
    }
}