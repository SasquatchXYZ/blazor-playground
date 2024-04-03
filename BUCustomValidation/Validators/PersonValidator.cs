using BUCustomValidation.Models;
using FluentValidation;

namespace BUCustomValidation.Validators;

public class PersonValidator : AbstractValidator<Person>
{
    public PersonValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Age).InclusiveBetween(18, 80);
    }
}
