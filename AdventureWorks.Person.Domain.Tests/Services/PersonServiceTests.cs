using AdventureWorks.Person.Domain.Services;
using AdventureWorks.Person.Domain.Services.Abstraction;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventureWorks.Person.Domain.Tests.Services
{
    [TestClass]
    public sealed class PersonServiceTests
    {
        private IPersonService _personService;

        [TestInitialize]
        public void Initialize()
        {
            this._personService = new PersonService();
        }

        [TestMethod]
        public void CreateWhenWithoutFirstNameShouldReturnNotificationWithValidation()
        {
            // Arrange
            string firstName = string.Empty;
            string middleName = "middle-name";
            string lastName = "last-name";

            // Act
            var result = this._personService.Create(firstName, middleName, lastName);

            // Assert
            result.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void CreateWhenWithoutMiddleNameShouldReturnNotificationWithValidation()
        {
            // Arrange
            string firstName = "first-name";
            string middleName = string.Empty;
            string lastName = "last-name";

            // Act
            var result = this._personService.Create(firstName, middleName, lastName);

            // Assert
            result.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void CreateWhenWithoutLastNameShouldReturnNotificationWithValidation()
        {
            // Arrange
            string firstName = "first-name";
            string middleName = "middle-name";
            string lastName = string.Empty;

            // Act
            var result = this._personService.Create(firstName, middleName, lastName);

            // Assert
            result.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void CreateWhenAllParametersValidShouldReturnNotificationValid()
        {
            // Arrange
            string firstName = "first-name";
            string middleName = "middle-name";
            string lastName = "last-name";

            // Act
            var result = this._personService.Create(firstName, middleName, lastName);

            // Assert
            result.IsValid.Should().BeTrue();
        }
    }
}
