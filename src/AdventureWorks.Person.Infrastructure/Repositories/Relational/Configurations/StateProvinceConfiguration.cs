using AdventureWorks.Person.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdventureWorks.Person.Infrastructure.Repositories.Relational.Configurations
{
    public sealed class StateProvinceConfiguration : IEntityTypeConfiguration<StateProvince>
    {
        public void Configure(EntityTypeBuilder<StateProvince> builder)
        {
            builder.ToTable("StateProvince", "Person");

            builder.HasComment("State and province lookup table.");

            builder.HasIndex(e => e.Name, "AK_StateProvince_Name")
                .IsUnique();

            builder.HasIndex(e => new { e.StateProvinceCode, e.CountryRegionCode }, "AK_StateProvince_StateProvinceCode_CountryRegionCode")
                .IsUnique();

            builder.HasIndex(e => e.Rowguid, "AK_StateProvince_rowguid")
                .IsUnique();

            builder.Property(e => e.StateProvinceId)
                .HasColumnName("StateProvinceID")
                .HasComment("Primary key for StateProvince records.");

            builder.Property(e => e.CountryRegionCode)
                .IsRequired()
                .HasMaxLength(3)
                .HasComment("ISO standard country or region code. Foreign key to CountryRegion.CountryRegionCode. ");

            builder.Property(e => e.IsOnlyStateProvinceFlag)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasComment("0 = StateProvinceCode exists. 1 = StateProvinceCode unavailable, using CountryRegionCode.");

            builder.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("State or province description.");

            builder.Property(e => e.Rowguid)
                .HasColumnName("rowguid")
                .HasDefaultValueSql("(newid())")
                .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");

            builder.Property(e => e.StateProvinceCode)
                .IsRequired()
                .HasMaxLength(3)
                .IsFixedLength(true)
                .HasComment("ISO standard state or province code.");

            builder.Property(e => e.TerritoryId)
                .HasColumnName("TerritoryID")
                .HasComment("ID of the territory in which the state or province is located. Foreign key to SalesTerritory.SalesTerritoryID.");

            builder.HasOne(d => d.CountryRegionCodeNavigation)
                .WithMany(p => p.StateProvinces)
                .HasForeignKey(d => d.CountryRegionCode)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
