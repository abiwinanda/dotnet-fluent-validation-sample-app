# Dotnet Fluent Validation Sample App

`FluentValidation` is a library in dotnet that allows you validate an input object. E.g in API request.
Will minimal configurations, the library allows you to set rules within models using Fluent API and let
the library do the validation for you.

## Dependencies

To use `FluentValidation` you must install the `FluentValidation` and `FluentValidation.AspNetCore` packages

```shell
dotnet add package FluentValidation
dotnet add package FluentValidation.AspNetCore
```

This sample project assumes that you are using dotnet 6.0

## Setting Up Fluent Validation

In `Program.cs` add the following configuration under `AddControllers()`

```csharp
builder.Services.AddFluentValidation(c => c.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
```

## Adding Validation Rule

Suppose you have a class or model called `Course` that you want to add validate rule. First, create
a class called `CourseValidator` (the name does not matter) that extend `AbstractValidator<Course>`

```csharp
public class CourseValidator : AbstractValidator<Course>
{
    ...
}
```

Next define the validation rule inside its constructor

```csharp
public class CourseValidator : AbstractValidator<Course>
{
    public CourseValidator()
    {
        RuleFor(c => c.Id)
            .NotNull();

        RuleFor(c => c.Name)
            .NotNull()
            .NotEmpty();
    }
}
```

If there is a nested validation (object within object) then you could either add validation to the nested
object using nested or modular approach

```csharp
public class CourseValidator : AbstractValidator<Course>
{
    public CourseValidator()
    {   
        // Nested approach
        RuleForEach(c => c.Videos)
            .ChildRules(child =>
            {
                child.RuleFor(v => v.Id)
                    .NotNull();
        
                child.RuleFor(v => v.Title)
                    .NotNull()
                    .NotEmpty();
            });
            
        // Modular approach
        RuleForEach(c => c.Videos)
            .SetValidator(new VideoValidator());
    }
}
```

## Error Message

If you have a POST API that accept `Course` as the input object then if the given input does not satisfy the rule
then `FluentValidation` will automatically return an error for you as follows

```shell
{
  "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
  "title": "One or more validation errors occurred.",
  "status": 400,
  "traceId": "00-efc0abbe5c1da33d72e7f324e377e0f6-6b3862477b2b8679-00",
  "errors": {
    "Name": [
      "'Name' must not be empty."
    ],
    "Videos[0].Title": [
      "'Title' must not be empty."
    ]
  }
}
```
