using AdventureWorks.Person.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdventureWorks.Person.Infrastructure.Repositories.Relational.Configurations
{
    public sealed class EmailAddressConfiguration : IEntityTypeConfiguration<EmailAddress>
    {
        public void Configure(EntityTypeBuilder<EmailAddress> builder)
        {
            builder.HasKey(e => new { e.BusinessEntityId, e.EmailAddressId })
                .HasName("PK_EmailAddress_BusinessEntityID_EmailAddressID");

            builder.ToTable("EmailAddress", "Person");

            builder.HasComment("Where to send a person email.");

            builder.HasIndex(e => e.EmailAddress1, "IX_EmailAddress_EmailAddress");

            builder.Property(e => e.BusinessEntityId)
                .HasColumnName("BusinessEntityID")
                .HasComment("Primary key. Person associated with this email address.  Foreign key to Person.BusinessEntityID");

            builder.Property(e => e.EmailAddressId)
                .ValueGeneratedOnAdd()
                .HasColumnName("EmailAddressID")
                .HasComment("Primary key. ID of this email address.");

            builder.Property(e => e.EmailAddress1)
                .HasMaxLength(50)
                .HasColumnName("EmailAddress")
                .HasComment("E-mail address for the person.");

            builder.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            builder.Property(e => e.Rowguid)
                .HasColumnName("rowguid")
                .HasDefaultValueSql("(newid())")
                .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");

            builder.HasOne(d => d.BusinessEntity)
                .WithMany(p => p.EmailAddresses)
                .HasForeignKey(d => d.BusinessEntityId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
