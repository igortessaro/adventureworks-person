using System;

namespace AdventureWorks.Person.Domain.Entities
{
    /// <summary>
    /// One way hashed authentication information
    /// </summary>
    public sealed class Password
    {
        public int BusinessEntityId { get; private set; }
        /// <summary>
        /// Password for the e-mail account.
        /// </summary>
        public string PasswordHash { get; private set; }
        /// <summary>
        /// Random value concatenated with the password string before the password is hashed.
        /// </summary>
        public string PasswordSalt { get; private set; }
        /// <summary>
        /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
        /// </summary>
        public Guid Rowguid { get; private set; }
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        public DateTime ModifiedDate { get; private set; }

        public Person BusinessEntity { get; private set; }
    }
}