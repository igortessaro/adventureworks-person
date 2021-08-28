using System;
using System.Collections.Generic;

namespace AdventureWorks.Person.Domain.Entities
{
    /// <summary>
    /// Cross-reference table mapping stores, vendors, and employees to people
    /// </summary>
    public sealed class BusinessEntityContact
    {
        /// <summary>
        /// Primary key. Foreign key to BusinessEntity.BusinessEntityID.
        /// </summary>
        public int BusinessEntityId { get; private set; }
        /// <summary>
        /// Primary key. Foreign key to Person.BusinessEntityID.
        /// </summary>
        public int PersonId { get; private set; }
        /// <summary>
        /// Primary key.  Foreign key to ContactType.ContactTypeID.
        /// </summary>
        public int ContactTypeId { get; private set; }
        /// <summary>
        /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
        /// </summary>
        public Guid Rowguid { get; private set; }
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        public DateTime ModifiedDate { get; private set; }

        public BusinessEntity BusinessEntity { get; private set; }
        public ContactType ContactType { get; private set; }
        public Person Person { get; private set; }
    }
}