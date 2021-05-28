using System;

namespace AdventureWorks.Person.Domain.Entities
{
    /// <summary>
    /// Telephone number and type of a person.
    /// </summary>
    public sealed class PersonPhone
    {
        /// <summary>
        /// Business entity identification number. Foreign key to Person.BusinessEntityID.
        /// </summary>
        public int BusinessEntityId { get; private set; }
        /// <summary>
        /// Telephone number identification number.
        /// </summary>
        public string PhoneNumber { get; private set; }
        /// <summary>
        /// Kind of phone number. Foreign key to PhoneNumberType.PhoneNumberTypeID.
        /// </summary>
        public int PhoneNumberTypeId { get; private set; }
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        public DateTime ModifiedDate { get; private set; }

        public Person BusinessEntity { get; private set; }
        public PhoneNumberType PhoneNumberType { get; private set; }
    }
}