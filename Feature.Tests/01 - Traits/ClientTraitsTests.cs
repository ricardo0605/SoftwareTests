using Feature.Clients;
using System;
using Xunit;

namespace Feature.Tests._01___Traits
{
    public class ClientTraitsTests
    {
        [Fact(DisplayName = "New client valid")]
        [Trait("Category", "Client trait")]
        public void Client_NewClient_IsValid()
        {
            // Arrange
            var client = new Client(Guid.NewGuid(),
                "Ricardo",
                "Pires",
                DateTime.Now.AddYears(-30),
                "ricardo.pires@gmail.com",
                true
            );

            // Act
            var result = client.IsValid();

            // Assert
            Assert.True(result);
            Assert.Equal(0, client.ValidationResult.Errors.Count);
        }

        [Fact(DisplayName = "New client is not valid")]
        [Trait("Category", "Client trait")]
        public void Client_NewClient_IsNotValid()
        {
            // Arrange
            var client = new Client(
                new System.Guid(),
                string.Empty,
                string.Empty,
                DateTime.Now,
                "ricardo.pires.com",
                true
            );

            // Act
            var result = client.IsValid();

            // Assert
            Assert.False(result);
            Assert.NotEqual(0, client.ValidationResult.Errors.Count);
        }
    }
}
