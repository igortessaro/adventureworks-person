using AdventureWorks.Person.Domain.Repositories;
using AdventureWorks.Person.Infrastructure.Repositories.Relational;
using Microsoft.EntityFrameworkCore;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class RepositoryServiceColletionExtensions
    {
        public static IServiceCollection AddPersonContext(this IServiceCollection services, string connectionString, bool useInMemoryDataBase = false)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            services.AddDbContext<PersonContext>(options =>
            {
                if (useInMemoryDataBase)
                {
                    options.UseInMemoryDatabase("dbInMemory");
                }
                else
                {
                    options.UseSqlServer(connectionString);
                }
            });

            return services;
        }

        public static IServiceCollection AddInfrastructureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPersonRepository, PersonRepository>();

            return services;
        }
    }
}
