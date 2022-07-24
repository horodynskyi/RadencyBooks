using FluentValidation;
using RadencyBooks.Application.Dtos;
using RadencyBooks.Application.Models;

namespace RadencyBooks.Application.Validators;

public class RatingDtoValidator:AbstractValidator<RatingDto>
{
    public RatingDtoValidator()
    {
        RuleFor(x => x.Score)
            .GreaterThanOrEqualTo(1)
            .LessThanOrEqualTo(5)
            .WithMessage("Score must be in range 1 to 5");
    }
}