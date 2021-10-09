using MediatR;

namespace AdventureWorks.Person.Domain.Commands.Person
{
    public record PersonQuery(bool All, string FirstName) : IRequest<Notification>;
}
