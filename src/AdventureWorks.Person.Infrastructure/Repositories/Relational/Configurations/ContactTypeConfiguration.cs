using AdventureWorks.Person.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdventureWorks.Person.Infrastructure.Repositories.Relational.Configurations
{
    public sealed class ContactTypeConfiguration : IEntityTypeConfiguration<ContactType>
    {
        public void Configure(EntityTypeBuilder<ContactType> builder)
        {
            builder.ToTable("ContactType", "Person");

            builder.HasComment("Lookup table containing the types of business entity contacts.");

            builder.HasIndex(e => e.Name, "AK_ContactType_Name")
                .IsUnique();

            builder.Property(e => e.ContactTypeId)
                .HasColumnName("ContactTypeID")
                .HasComment("Primary key for ContactType records.");

            builder.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("Contact type description.");
        }
    }
}
