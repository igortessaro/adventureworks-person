using AdventureWorks.Person.Domain.Services.Abstraction;

namespace AdventureWorks.Person.Domain.Services
{
    public sealed class PersonService : IPersonService
    {
        public string Create(string firstName, string middleName, string lastName)
        {
            return $"{nameof(PersonService)}-{firstName}, {middleName}, {lastName}";
        }
    }
}
