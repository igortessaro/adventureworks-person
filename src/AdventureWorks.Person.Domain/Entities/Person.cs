using AdventureWorks.Person.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace AdventureWorks.Person.Domain.Entities
{
    /// <summary>
    /// Human beings involved with AdventureWorks: employees, customer contacts, and vendor contacts.
    /// </summary>
    public sealed class Person
    {
        public Person()
        {
            BusinessEntityContacts = new HashSet<BusinessEntityContact>();
            EmailAddresses = new HashSet<EmailAddress>();
            PersonPhones = new HashSet<PersonPhone>();
        }

        /// <summary>
        /// Primary key for Person records.
        /// </summary>
        public int BusinessEntityId { get; private set; }
        /// <summary>
        /// Primary type of person: SC = Store Contact, IN = Individual (retail) customer, SP = Sales person, EM = Employee (non-sales), VC = Vendor contact, GC = General contact
        /// </summary>
        public PersonType Type { get; private set; }
        /// <summary>
        /// 0 = The data in FirstName and LastName are stored in western style (first name, last name) order.  1 = Eastern style (last name, first name) order.
        /// </summary>
        public bool NameStyle { get; private set; }
        /// <summary>
        /// A courtesy title. For example, Mr. or Ms.
        /// </summary>
        public string Title { get; private set; }
        /// <summary>
        /// First name of the person.
        /// </summary>
        public string FirstName { get; private set; }
        /// <summary>
        /// Middle name or middle initial of the person.
        /// </summary>
        public string MiddleName { get; private set; }
        /// <summary>
        /// Last name of the person.
        /// </summary>
        public string LastName { get; private set; }
        /// <summary>
        /// Surname suffix. For example, Sr. or Jr.
        /// </summary>
        public string Suffix { get; private set; }
        /// <summary>
        /// 0 = Contact does not wish to receive e-mail promotions, 1 = Contact does wish to receive e-mail promotions from AdventureWorks, 2 = Contact does wish to receive e-mail promotions from AdventureWorks and selected partners. 
        /// </summary>
        public int EmailPromotion { get; private set; }
        /// <summary>
        /// Additional contact information about the person stored in xml format. 
        /// </summary>
        public string AdditionalContactInfo { get; private set; }
        /// <summary>
        /// Personal information such as hobbies, and income collected from online shoppers. Used for sales analysis.
        /// </summary>
        public string Demographics { get; private set; }
        /// <summary>
        /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
        /// </summary>
        public Guid Rowguid { get; private set; }
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        public DateTime ModifiedDate { get; private set; }

        public BusinessEntity BusinessEntity { get; private set; }
        public Password Password { get; private set; }
        public ICollection<BusinessEntityContact> BusinessEntityContacts { get; private set; }
        public ICollection<EmailAddress> EmailAddresses { get; private set; }
        public ICollection<PersonPhone> PersonPhones { get; private set; }
    }
}