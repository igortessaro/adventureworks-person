using AdventureWorks.Person.Infrastructure.Repositories.Relational.Profiles;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AutoMapperServiceColletionExtensions
    {
        public static IServiceCollection AddInfrastructureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(x => x.AddProfile<PersonProfile>());

            return services;
        }
    }
}
