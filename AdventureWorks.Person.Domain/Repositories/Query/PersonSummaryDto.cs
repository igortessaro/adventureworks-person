namespace AdventureWorks.Person.Domain.Repositories.Query
{
    public sealed class PersonSummaryDto
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PasswordHash { get; set; }
    }
}
