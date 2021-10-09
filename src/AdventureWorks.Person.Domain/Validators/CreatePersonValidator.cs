using AdventureWorks.Person.Domain.Commands.Person;
using FluentValidation;

namespace AdventureWorks.Person.Domain.Validators
{
    public sealed class CreatePersonValidator : AbstractValidator<CreatePersonCommand>
    {
        public CreatePersonValidator()
        {
            RuleFor(a => a.FirstName).NotEmpty();
            RuleFor(a => a.MiddleName).NotEmpty();
            RuleFor(a => a.LastName).NotEmpty();
        }
    }
}
