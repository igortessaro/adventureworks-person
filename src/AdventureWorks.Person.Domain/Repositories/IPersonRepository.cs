using AdventureWorks.Person.Domain.Repositories.Core;
using AdventureWorks.Person.Domain.Repositories.Query;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorks.Person.Domain.Repositories
{
    public interface IPersonRepository: IBaseRepository<Entities.Person>
    {
        Task<IReadOnlyCollection<PersonSummaryDto>> GetAll();
        Task<IReadOnlyCollection<PersonSummaryDto>> GetCompleteByName(string name);
    }
}
