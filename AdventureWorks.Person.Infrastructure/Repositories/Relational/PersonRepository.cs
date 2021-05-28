using AdventureWorks.Person.Domain.Repositories;
using AdventureWorks.Person.Domain.Repositories.Query;
using AdventureWorks.Person.Infrastructure.Repositories.Relational.Core;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorks.Person.Infrastructure.Repositories.Relational
{
    public sealed class PersonRepository : BaseRepository<Domain.Entities.Person>, IPersonRepository
    {
        public PersonRepository(PersonContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public Task<List<PersonSummaryDto>> GetAll()
        {
            var result = this.Query<PersonSummaryDto>().Take(10).ToListAsync();

            return result;
        }

        public Task<List<PersonSummaryDto>> GetCompleteByName(string name)
        {
            string nameUpper = name.ToUpper();

            var result = this.QueryComplete()
                .Where(x => nameUpper.Equals(x.FirstName.ToUpper()))
                .Select(x => new PersonSummaryDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    MiddleName = x.MiddleName,
                    PasswordHash = x.Password.PasswordHash
                })
                .ToListAsync();

            return result;
        }

        private IQueryable<Domain.Entities.Person> QueryComplete()
        {
            return this.Query()
                .Include(x => x.Password)
                .Include(x => x.BusinessEntity)
                .Include(x => x.BusinessEntityContacts)
                .Include(x => x.EmailAddresses)
                .Include(x => x.PersonPhones);
        }
    }
}
