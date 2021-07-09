using AdventureWorks.Person.Domain.Notification;

namespace AdventureWorks.Person.Domain.Services.Abstraction
{
    public interface IPersonService
    {
        Notification<string> Create(string firstName, string middleName, string lastName);
    }
}
