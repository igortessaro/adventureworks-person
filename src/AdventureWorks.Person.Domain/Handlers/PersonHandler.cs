using AdventureWorks.Person.Domain.Commands.Person;
using AdventureWorks.Person.Domain.Notification;
using AdventureWorks.Person.Domain.Repositories;
using AdventureWorks.Person.Domain.Repositories.Query;
using AdventureWorks.Person.Domain.Services.Abstraction;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorks.Person.Domain.Handlers
{
    public sealed class PersonHandler : IRequestHandler<CreatePersonCommand, Notification<string>>, IRequestHandler<PersonQuery, Notification<List<PersonSummaryDto>>>
    {
        private readonly IPersonService _personService;
        private readonly IPersonRepository _personRepository;

        public PersonHandler(IPersonService personService, IPersonRepository personRepository)
        {
            _personService = personService;
            _personRepository = personRepository;
        }

        public Task<Notification<string>> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var result = _personService.Create(request.FirstName, request.MiddleName, request.LastName);

            return Task.FromResult(result);
        }

        public Task<Notification<List<PersonSummaryDto>>> Handle(PersonQuery request, CancellationToken cancellationToken)
        {
            if (request.All)
            {
                return _personRepository.GetAll();
            }

            return _personRepository.GetCompleteByName(request.FirstName);
        }
    }
}
