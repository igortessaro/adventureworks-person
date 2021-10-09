using AdventureWorks.Person.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdventureWorks.Person.Infrastructure.Repositories.Relational.Configurations
{
    public sealed class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address", "Person");

            builder.HasComment("Street address information for customers, employees, and vendors.");

            builder.HasIndex(e => e.Rowguid, "AK_Address_rowguid")
                .IsUnique();

            builder.HasIndex(e => new { e.AddressLine1, e.AddressLine2, e.City, e.StateProvinceId, e.PostalCode }, "IX_Address_AddressLine1_AddressLine2_City_StateProvinceID_PostalCode")
                .IsUnique();

            builder.HasIndex(e => e.StateProvinceId, "IX_Address_StateProvinceID");

            builder.Property(e => e.AddressId)
                .HasColumnName("AddressID")
                .HasComment("Primary key for Address records.");

            builder.Property(e => e.AddressLine1)
                .IsRequired()
                .HasMaxLength(60)
                .HasComment("First street address line.");

            builder.Property(e => e.AddressLine2)
                .HasMaxLength(60)
                .HasComment("Second street address line.");

            builder.Property(e => e.City)
                .IsRequired()
                .HasMaxLength(30)
                .HasComment("Name of the city.");

            builder.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            builder.Property(e => e.PostalCode)
                .IsRequired()
                .HasMaxLength(15)
                .HasComment("Postal code for the street address.");

            builder.Property(e => e.Rowguid)
                .HasColumnName("rowguid")
                .HasDefaultValueSql("(newid())")
                .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");

            builder.Property(e => e.StateProvinceId)
                .HasColumnName("StateProvinceID")
                .HasComment("Unique identification number for the state or province. Foreign key to StateProvince table.");

            builder.HasOne(d => d.StateProvince)
                .WithMany(p => p.Addresses)
                .HasForeignKey(d => d.StateProvinceId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
