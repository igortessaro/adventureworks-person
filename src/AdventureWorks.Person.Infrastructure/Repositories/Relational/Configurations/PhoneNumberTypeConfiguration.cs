using AdventureWorks.Person.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdventureWorks.Person.Infrastructure.Repositories.Relational.Configurations
{
    public sealed class PhoneNumberTypeConfiguration : IEntityTypeConfiguration<PhoneNumberType>
    {
        public void Configure(EntityTypeBuilder<PhoneNumberType> builder)
        {
            builder.ToTable("PhoneNumberType", "Person");

            builder.HasComment("Type of phone number of a person.");

            builder.Property(e => e.PhoneNumberTypeId)
                .HasColumnName("PhoneNumberTypeID")
                .HasComment("Primary key for telephone number type records.");

            builder.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("Name of the telephone number type");
        }
    }
}
