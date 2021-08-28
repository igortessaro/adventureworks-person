using AdventureWorks.Person.Domain.Repositories.Query;
using AutoMapper;

namespace AdventureWorks.Person.Infrastructure.Repositories.Relational.Profiles
{
    public sealed class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Domain.Entities.Person, PersonSummaryDto>().ForMember(x => x.PasswordHash, source => source.MapFrom(y => y.Password.PasswordHash));
        }
    }
}
