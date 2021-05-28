using System;
using System.Collections.Generic;

namespace AdventureWorks.Person.Domain.Entities
{
    /// <summary>
    /// Type of phone number of a person.
    /// </summary>
    public sealed class PhoneNumberType
    {
        public PhoneNumberType()
        {
            PersonPhones = new HashSet<PersonPhone>();
        }

        /// <summary>
        /// Primary key for telephone number type records.
        /// </summary>
        public int PhoneNumberTypeId { get; private set; }
        /// <summary>
        /// Name of the telephone number type
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        public DateTime ModifiedDate { get; private set; }

        public ICollection<PersonPhone> PersonPhones { get; private set; }
    }
}