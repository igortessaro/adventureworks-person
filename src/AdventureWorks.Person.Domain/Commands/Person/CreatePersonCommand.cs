using AdventureWorks.Person.Domain.Notification;
using MediatR;

namespace AdventureWorks.Person.Domain.Commands.Person
{
    public sealed class CreatePersonCommand : IRequest<Notification<string>>
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }
}
