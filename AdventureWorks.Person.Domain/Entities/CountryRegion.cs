using System;
using System.Collections.Generic;

namespace AdventureWorks.Person.Domain.Entities
{
    /// <summary>
    /// Lookup table containing the ISO standard codes for countries and regions.
    /// </summary>
    public sealed class CountryRegion
    {
        public CountryRegion()
        {
            StateProvinces = new HashSet<StateProvince>();
        }

        /// <summary>
        /// ISO standard code for countries and regions.
        /// </summary>
        public string CountryRegionCode { get; private set; }
        /// <summary>
        /// Country or region name.
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        public DateTime ModifiedDate { get; private set; }

        public ICollection<StateProvince> StateProvinces { get; private set; }
    }
}