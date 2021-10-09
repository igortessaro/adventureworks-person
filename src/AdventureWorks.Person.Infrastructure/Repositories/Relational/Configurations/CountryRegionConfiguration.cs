using AdventureWorks.Person.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdventureWorks.Person.Infrastructure.Repositories.Relational.Configurations
{
    public sealed class CountryRegionConfiguration : IEntityTypeConfiguration<CountryRegion>
    {
        public void Configure(EntityTypeBuilder<CountryRegion> builder)
        {
            builder.HasKey(e => e.CountryRegionCode)
                .HasName("PK_CountryRegion_CountryRegionCode");

            builder.ToTable("CountryRegion", "Person");

            builder.HasComment("Lookup table containing the ISO standard codes for countries and regions.");

            builder.HasIndex(e => e.Name, "AK_CountryRegion_Name")
                .IsUnique();

            builder.Property(e => e.CountryRegionCode)
                .HasMaxLength(3)
                .HasComment("ISO standard code for countries and regions.");

            builder.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("Country or region name.");
        }
    }
}
