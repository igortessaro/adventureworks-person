using AdventureWorks.Person.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdventureWorks.Person.Infrastructure.Repositories.Relational.Configurations
{
    public sealed class PasswordConfiguration : IEntityTypeConfiguration<Password>
    {
        public void Configure(EntityTypeBuilder<Password> entity)
        {
            entity.HasKey(e => e.BusinessEntityId)
                .HasName("PK_Password_BusinessEntityID");

            entity.ToTable("Password", "Person");

            entity.HasComment("One way hashed authentication information");

            entity.Property(e => e.BusinessEntityId)
                .ValueGeneratedNever()
                .HasColumnName("BusinessEntityID");

            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.PasswordHash)
                .IsRequired()
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasComment("Password for the e-mail account.");

            entity.Property(e => e.PasswordSalt)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasComment("Random value concatenated with the password string before the password is hashed.");

            entity.Property(e => e.Rowguid)
                .HasColumnName("rowguid")
                .HasDefaultValueSql("(newid())")
                .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");

            entity.HasOne(d => d.BusinessEntity)
                .WithOne(p => p.Password)
                .HasForeignKey<Password>(d => d.BusinessEntityId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
