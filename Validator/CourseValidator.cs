using FluentValidation;
using SampleFluentValidation.Models;

namespace SampleFluentValidation.Validator;

public class CourseValidator : AbstractValidator<Course>
{
    public CourseValidator()
    {
        RuleFor(c => c.Id)
            .NotNull();

        RuleFor(c => c.Name)
            .NotNull()
            .NotEmpty();
        
        // Modular approach
        RuleForEach(c => c.Videos)
            .SetValidator(new VideoValidator());

        // Nested approach
        // RuleForEach(c => c.Videos)
        //     .ChildRules(child =>
        //     {
        //         child.RuleFor(v => v.Id)
        //             .NotNull();
        //
        //         child.RuleFor(v => v.Title)
        //             .NotNull()
        //             .NotEmpty();
        //     });
    }
}