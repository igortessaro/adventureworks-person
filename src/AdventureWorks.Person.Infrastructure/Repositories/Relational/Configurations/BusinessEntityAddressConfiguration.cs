using AdventureWorks.Person.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdventureWorks.Person.Infrastructure.Repositories.Relational.Configurations
{
    public sealed class BusinessEntityAddressConfiguration : IEntityTypeConfiguration<BusinessEntityAddress>
    {
        public void Configure(EntityTypeBuilder<BusinessEntityAddress> builder)
        {
            builder.HasKey(e => new { e.BusinessEntityId, e.AddressId, e.AddressTypeId })
                .HasName("PK_BusinessEntityAddress_BusinessEntityID_AddressID_AddressTypeID");

            builder.ToTable("BusinessEntityAddress", "Person");

            builder.HasComment("Cross-reference table mapping customers, vendors, and employees to their addresses.");

            builder.HasIndex(e => e.Rowguid, "AK_BusinessEntityAddress_rowguid")
                .IsUnique();

            builder.HasIndex(e => e.AddressId, "IX_BusinessEntityAddress_AddressID");

            builder.HasIndex(e => e.AddressTypeId, "IX_BusinessEntityAddress_AddressTypeID");

            builder.Property(e => e.BusinessEntityId)
                .HasColumnName("BusinessEntityID")
                .HasComment("Primary key. Foreign key to BusinessEntity.BusinessEntityID.");

            builder.Property(e => e.AddressId)
                .HasColumnName("AddressID")
                .HasComment("Primary key. Foreign key to Address.AddressID.");

            builder.Property(e => e.AddressTypeId)
                .HasColumnName("AddressTypeID")
                .HasComment("Primary key. Foreign key to AddressType.AddressTypeID.");

            builder.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            builder.Property(e => e.Rowguid)
                .HasColumnName("rowguid")
                .HasDefaultValueSql("(newid())")
                .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");

            builder.HasOne(d => d.Address)
                .WithMany(p => p.BusinessEntityAddresses)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.AddressType)
                .WithMany(p => p.BusinessEntityAddresses)
                .HasForeignKey(d => d.AddressTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.BusinessEntity)
                .WithMany(p => p.BusinessEntityAddresses)
                .HasForeignKey(d => d.BusinessEntityId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
