using AdventureWorks.Person.Domain.Notification;
using AdventureWorks.Person.Domain.Repositories.Core;
using AdventureWorks.Person.Domain.Repositories.Query;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorks.Person.Domain.Repositories
{
    public interface IPersonRepository: IBaseRepository<Entities.Person>
    {
        Task<Notification<List<PersonSummaryDto>>> GetAll();
        Task<Notification<List<PersonSummaryDto>>> GetCompleteByName(string name);
    }
}
