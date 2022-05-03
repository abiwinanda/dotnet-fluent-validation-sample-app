using FluentValidation;
using SampleFluentValidation.Models;

namespace SampleFluentValidation.Validator;

public class VideoValidator : AbstractValidator<Video>
{
    public VideoValidator()
    {
        RuleFor(v => v.Id)
            .NotNull();

        RuleFor(v => v.Title)
            .NotNull()
            .NotEmpty();
    }
}