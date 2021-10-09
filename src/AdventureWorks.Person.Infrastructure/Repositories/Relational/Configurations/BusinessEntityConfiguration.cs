using AdventureWorks.Person.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdventureWorks.Person.Infrastructure.Repositories.Relational.Configurations
{
    public sealed class BusinessEntityConfiguration : IEntityTypeConfiguration<BusinessEntity>
    {
        public void Configure(EntityTypeBuilder<BusinessEntity> builder)
        {
            builder.ToTable("BusinessEntity", "Person");

            builder.HasComment("Source of the ID that connects vendors, customers, and employees with address and contact information.");

            builder.HasIndex(e => e.Rowguid, "AK_BusinessEntity_rowguid")
                .IsUnique();

            builder.Property(e => e.BusinessEntityId)
                .HasColumnName("BusinessEntityID")
                .HasComment("Primary key for all customers, vendors, and employees.");

            builder.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            builder.Property(e => e.Rowguid)
                .HasColumnName("rowguid")
                .HasDefaultValueSql("(newid())")
                .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");
        }
    }
}
