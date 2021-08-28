using AdventureWorks.Person.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AdventureWorks.Person.Infrastructure.Repositories.Relational
{
    public sealed class PersonContext : DbContext
    {
        public PersonContext()
        {
        }

        public PersonContext(DbContextOptions<PersonContext> options)
            : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<AddressType> AddressTypes { get; set; }
        public DbSet<BusinessEntity> BusinessEntities { get; set; }
        public DbSet<BusinessEntityAddress> BusinessEntityAddresses { get; set; }
        public DbSet<BusinessEntityContact> BusinessEntityContacts { get; set; }
        public DbSet<ContactType> ContactTypes { get; set; }
        public DbSet<CountryRegion> CountryRegions { get; set; }
        public DbSet<EmailAddress> EmailAddresses { get; set; }
        public DbSet<Password> Passwords { get; set; }
        public DbSet<Domain.Entities.Person> People { get; set; }
        public DbSet<PersonPhone> PersonPhones { get; set; }
        public DbSet<PhoneNumberType> PhoneNumberTypes { get; set; }
        public DbSet<StateProvince> StateProvinces { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(message => Debug.WriteLine(message));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.ApplyConfiguration(new Configurations.AddressConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.AddressTypeConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.BusinessEntityConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.BusinessEntityAddressConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.BusinessEntityContactConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.ContactTypeConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.CountryRegionConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.EmailAddressConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.PasswordConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.PersonConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.PersonPhoneConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.PhoneNumberTypeConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.StateProvinceConfiguration());
        }
    }
}
