using AdventureWorks.Person.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdventureWorks.Person.Infrastructure.Repositories.Relational.Configurations
{
    public sealed class PersonPhoneConfiguration : IEntityTypeConfiguration<PersonPhone>
    {
        public void Configure(EntityTypeBuilder<PersonPhone> builder)
        {
            builder.HasKey(e => new { e.BusinessEntityId, e.PhoneNumber, e.PhoneNumberTypeId })
                .HasName("PK_PersonPhone_BusinessEntityID_PhoneNumber_PhoneNumberTypeID");

            builder.ToTable("PersonPhone", "Person");

            builder.HasComment("Telephone number and type of a person.");

            builder.HasIndex(e => e.PhoneNumber, "IX_PersonPhone_PhoneNumber");

            builder.Property(e => e.BusinessEntityId)
                .HasColumnName("BusinessEntityID")
                .HasComment("Business entity identification number. Foreign key to Person.BusinessEntityID.");

            builder.Property(e => e.PhoneNumber)
                .HasMaxLength(25)
                .HasComment("Telephone number identification number.");

            builder.Property(e => e.PhoneNumberTypeId)
                .HasColumnName("PhoneNumberTypeID")
                .HasComment("Kind of phone number. Foreign key to PhoneNumberType.PhoneNumberTypeID.");

            builder.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            builder.HasOne(d => d.BusinessEntity)
                .WithMany(p => p.PersonPhones)
                .HasForeignKey(d => d.BusinessEntityId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.PhoneNumberType)
                .WithMany(p => p.PersonPhones)
                .HasForeignKey(d => d.PhoneNumberTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
