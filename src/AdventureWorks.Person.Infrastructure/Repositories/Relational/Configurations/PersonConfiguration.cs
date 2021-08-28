using AdventureWorks.Person.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AdventureWorks.Person.Infrastructure.Repositories.Relational.Configurations
{
    public sealed class PersonConfiguration : IEntityTypeConfiguration<Domain.Entities.Person>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Person> entity)
        {
            entity.HasKey(e => e.BusinessEntityId).HasName("PK_Person_BusinessEntityID");

            entity.ToTable("Person", "Person");

            entity.HasComment("Human beings involved with AdventureWorks: employees, customer contacts, and vendor contacts.");

            entity.HasIndex(e => e.Rowguid, "AK_Person_rowguid").IsUnique();
            entity.HasIndex(e => new { e.LastName, e.FirstName, e.MiddleName }, "IX_Person_LastName_FirstName_MiddleName");
            entity.HasIndex(e => e.AdditionalContactInfo, "PXML_Person_AddContact");
            entity.HasIndex(e => e.Demographics, "PXML_Person_Demographics");
            entity.HasIndex(e => e.Demographics, "XMLPATH_Person_Demographics");
            entity.HasIndex(e => e.Demographics, "XMLPROPERTY_Person_Demographics");
            entity.HasIndex(e => e.Demographics, "XMLVALUE_Person_Demographics");

            entity.Property(e => e.BusinessEntityId)
                .ValueGeneratedNever()
                .HasColumnName("BusinessEntityID")
                .HasComment("Primary key for Person records.");

            entity.Property(e => e.AdditionalContactInfo)
                .HasColumnType("xml")
                .HasComment("Additional contact information about the person stored in xml format. ");

            entity.Property(e => e.Demographics)
                .HasColumnType("xml")
                .HasComment("Personal information such as hobbies, and income collected from online shoppers. Used for sales analysis.");

            entity.Property(e => e.EmailPromotion).HasComment("0 = Contact does not wish to receive e-mail promotions, 1 = Contact does wish to receive e-mail promotions from AdventureWorks, 2 = Contact does wish to receive e-mail promotions from AdventureWorks and selected partners. ");

            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("First name of the person.");

            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("Last name of the person.");

            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .HasComment("Middle name or middle initial of the person.");

            entity.Property(e => e.ModifiedDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Date and time the record was last updated.");

            entity.Property(e => e.NameStyle).HasComment("0 = The data in FirstName and LastName are stored in western style (first name, last name) order.  1 = Eastern style (last name, first name) order.");

            entity.Property(e => e.Type)
                .HasColumnName("PersonType")
                .HasConversion(type => type.ToString(), type => (PersonType)Enum.Parse(typeof(PersonType), type))
                .IsRequired()
                .HasMaxLength(2)
                .IsFixedLength(true)
                .HasComment("Primary type of person: SC = Store Contact, IN = Individual (retail) customer, SP = Sales person, EM = Employee (non-sales), VC = Vendor contact, GC = General contact");

            entity.Property(e => e.Rowguid)
                .HasColumnName("rowguid")
                .HasDefaultValueSql("(newid())")
                .HasComment("ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.");

            entity.Property(e => e.Suffix)
                .HasMaxLength(10)
                .HasComment("Surname suffix. For example, Sr. or Jr.");

            entity.Property(e => e.Title)
                .HasMaxLength(8)
                .HasComment("A courtesy title. For example, Mr. or Ms.");

            entity.HasOne(d => d.BusinessEntity)
                .WithOne(p => p.Person)
                .HasForeignKey<Domain.Entities.Person>(d => d.BusinessEntityId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
