using AdventureWorks.Person.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdventureWorks.Person.Infrastructure.Repositories.Relational.Configurations
{
    public sealed class BusinessEntityContactConfiguration : IEntityTypeConfiguration<BusinessEntityContact>
    {
        public void Configure(EntityTypeBuilder<BusinessEntityContact> builder)
        {
            builder.HasKey(e => new { e.BusinessEntityId, e.PersonId, e.ContactTypeId })
                .HasName("PK_BusinessEntityContact_BusinessEntityID_PersonID_ContactTypeID");

            builder.ToTable("BusinessEntityContact", "Person");

            builder.HasComment("Cross-reference table mapping stores, vendors, and employees to people");

            builder.HasIndex(e => e.Rowguid, "AK_BusinessEntityContact_rowguid")
                .IsUnique();

            builder.HasIndex(e => e.ContactTypeId, "IX_BusinessEntityContact_ContactTypeID");

            builder.HasIndex(e => e.PersonId, "IX_BusinessEntityContact_PersonID");

            builder.Property(e => e.BusinessEntityId)
                .HasColumnName("BusinessEntityID")
                .HasComment("Primary key. Foreign key to BusinessEntity.BusinessEntityID.");

            builder.Property(e => e.PersonId)
                .HasColumnName("PersonID")
                .HasComment("Primary key. Foreign key to Person.BusinessEntityID.");

            builder.Property(e => e.ContactTypeId)
                .HasColumnName("ContactTypeID")
                .HasComment("Primary key.  Foreign key to ContactType.ContactTypeID.");

            builder.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            builder.Property(e => e.Rowguid)
                .HasColumnName("rowguid")
                .HasDefaultValueSql("(newid())")
                .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");

            builder.HasOne(d => d.BusinessEntity)
                .WithMany(p => p.BusinessEntityContacts)
                .HasForeignKey(d => d.BusinessEntityId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.ContactType)
                .WithMany(p => p.BusinessEntityContacts)
                .HasForeignKey(d => d.ContactTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.Person)
                .WithMany(p => p.BusinessEntityContacts)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
