using AdventureWorks.Person.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdventureWorks.Person.Infrastructure.Repositories.Relational.Configurations
{
    public sealed class AddressTypeConfiguration : IEntityTypeConfiguration<AddressType>
    {
        public void Configure(EntityTypeBuilder<AddressType> builder)
        {
            builder.ToTable("AddressType", "Person");

            builder.HasComment("Types of addresses stored in the Address table. ");

            builder.HasIndex(e => e.Name, "AK_AddressType_Name")
                .IsUnique();

            builder.HasIndex(e => e.Rowguid, "AK_AddressType_rowguid")
                .IsUnique();

            builder.Property(e => e.AddressTypeId)
                .HasColumnName("AddressTypeID")
                .HasComment("Primary key for AddressType records.");

            builder.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("Address type description. For example, Billing, Home, or Shipping.");

            builder.Property(e => e.Rowguid)
                .HasColumnName("rowguid")
                .HasDefaultValueSql("(newid())")
                .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");
        }
    }
}
