using AdventureWorks.Person.Domain.Repositories.Core;
using AdventureWorks.Person.Domain.Repositories.Query;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorks.Person.Domain.Repositories
{
    public interface IPersonRepository: IBaseRepository<Entities.Person>
    {
        Task<List<PersonSummaryDto>> GetAll();
        Task<List<PersonSummaryDto>> GetCompleteByName(string name);
    }
}
