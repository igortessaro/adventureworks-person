using AdventureWorks.Person.Domain.Notification;
using AdventureWorks.Person.Domain.Services.Abstraction;

namespace AdventureWorks.Person.Domain.Services
{
    public sealed class PersonService : IPersonService
    {
        public Notification<string> Create(string firstName, string middleName, string lastName)
        {
            var result = new Notification<string>();

            if (string.IsNullOrEmpty(firstName))
            {
                result.AddValidation($"'{nameof(firstName)}' cannot be null or empty.");
            }

            if (string.IsNullOrEmpty(middleName))
            {
                result.AddValidation($"'{nameof(middleName)}' cannot be null or empty.");
            }

            if (string.IsNullOrEmpty(lastName))
            {
                result.AddValidation($"'{nameof(lastName)}' cannot be null or empty.");
            }

            if (!result.IsValid)
            {
                return result;
            }

            result.SetData($"{nameof(PersonService)}-{firstName}, {middleName}, {lastName}");

            return result;
        }
    }
}
