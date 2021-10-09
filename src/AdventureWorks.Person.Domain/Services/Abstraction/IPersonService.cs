namespace AdventureWorks.Person.Domain.Services.Abstraction
{
    public interface IPersonService
    {
        string Create(string firstName, string middleName, string lastName);
    }
}
