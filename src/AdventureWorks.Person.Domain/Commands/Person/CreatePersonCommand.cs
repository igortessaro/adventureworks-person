using MediatR;

namespace AdventureWorks.Person.Domain.Commands.Person
{
    public sealed class CreatePersonCommand : IRequest<Notification>
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public CreatePersonCommand(string firstName, string middleName, string lastName)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
        }
    }
}
