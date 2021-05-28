using System.ComponentModel;

namespace AdventureWorks.Person.Domain.ValueObjects
{
    public enum PersonType
    {
        [Description("Store Contact")]
        SC,
        [Description("Individual(retail) customer")]
        IN,
        [Description("Sales person")]
        SP,
        [Description("Employee(non - sales)")]
        EM,
        [Description("Vendor contact")]
        VC,
        [Description("General contact")]
        GC
    }
}
