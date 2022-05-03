using FluentValidation;

namespace SampleFluentValidation;

public class TodoValidator : AbstractValidator<Todo>
{
    public TodoValidator()
    {
        RuleFor(t => t.Title)
            .NotNull()
            .NotEmpty()
            .WithMessage("Title must be filled to create todo");
    }
}