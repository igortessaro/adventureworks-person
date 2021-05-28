﻿using System;
using System.Collections.Generic;

namespace AdventureWorks.Person.Domain.Entities
{
    /// <summary>
    /// State and province lookup table.
    /// </summary>
    public sealed class StateProvince
    {
        public StateProvince()
        {
            Addresses = new HashSet<Address>();
        }

        /// <summary>
        /// Primary key for StateProvince records.
        /// </summary>
        public int StateProvinceId { get; private set; }
        /// <summary>
        /// ISO standard state or province code.
        /// </summary>
        public string StateProvinceCode { get; private set; }
        /// <summary>
        /// ISO standard country or region code. Foreign key to CountryRegion.CountryRegionCode. 
        /// </summary>
        public string CountryRegionCode { get; private set; }
        /// <summary>
        /// 0 = StateProvinceCode exists. 1 = StateProvinceCode unavailable, using CountryRegionCode.
        /// </summary>
        public bool? IsOnlyStateProvinceFlag { get; private set; }
        /// <summary>
        /// State or province description.
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// ID of the territory in which the state or province is located. Foreign key to SalesTerritory.SalesTerritoryID.
        /// </summary>
        public int TerritoryId { get; private set; }
        /// <summary>
        /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
        /// </summary>
        public Guid Rowguid { get; private set; }
        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        public DateTime ModifiedDate { get; private set; }

        public CountryRegion CountryRegionCodeNavigation { get; private set; }
        public ICollection<Address> Addresses { get; private set; }
    }
}