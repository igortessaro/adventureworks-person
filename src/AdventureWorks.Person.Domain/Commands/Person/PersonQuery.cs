using AdventureWorks.Person.Domain.Notification;
using AdventureWorks.Person.Domain.Repositories.Query;
using MediatR;
using System.Collections.Generic;

namespace AdventureWorks.Person.Domain.Commands.Person
{
    public record PersonQuery(bool All, string FirstName) : IRequest<Notification<List<PersonSummaryDto>>>;
}
