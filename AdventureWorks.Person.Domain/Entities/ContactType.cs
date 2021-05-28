using System;
using System.Collections.Generic;

namespace AdventureWorks.Person.Domain.Entities
{
    /// <summary>
    /// Lookup table containing the types of business entity contacts.
    /// </summary>
    public sealed class ContactType
    {
        public ContactType()
        {
            BusinessEntityContacts = new HashSet<BusinessEntityContact>();
        }

        /// <summary>
        /// Primary key for ContactType records.
        /// </summary>
        public int ContactTypeId { get; private set; }
        /// <summary>
        /// Contact type description.
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        public DateTime ModifiedDate { get; private set; }

        public ICollection<BusinessEntityContact> BusinessEntityContacts { get; private set; }
    }
}