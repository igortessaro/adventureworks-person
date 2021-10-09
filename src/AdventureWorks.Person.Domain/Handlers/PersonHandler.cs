using AdventureWorks.Person.Domain.Commands.Person;
using AdventureWorks.Person.Domain.Repositories;
using AdventureWorks.Person.Domain.Services.Abstraction;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorks.Person.Domain.Handlers
{
    public sealed class PersonHandler : IRequestHandler<CreatePersonCommand, Notification>, IRequestHandler<PersonQuery, Notification>
    {
        private readonly IPersonService _personService;
        private readonly IPersonRepository _personRepository;

        public PersonHandler(IPersonService personService, IPersonRepository personRepository)
        {
            _personService = personService;
            _personRepository = personRepository;
        }

        public Task<Notification> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var result = _personService.Create(request.FirstName, request.MiddleName, request.LastName);

            return Task.FromResult(new Notification(result));
        }

        public async Task<Notification> Handle(PersonQuery request, CancellationToken cancellationToken)
        {
            if (request.All)
            {
                return new Notification(await _personRepository.GetAll());
            }

            return new Notification(_personRepository.GetCompleteByName(request.FirstName));
        }
    }
}
