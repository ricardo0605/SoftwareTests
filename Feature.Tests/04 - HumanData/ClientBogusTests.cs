using Bogus;
using Bogus.DataSets;
using Feature.Clients;
using System;
using Xunit;

namespace Feature.Tests._04___HumanData
{
    /// <summary>
    /// https://github.com/bchavez/Bogus
    /// </summary>
    public class ClientBogusTests
    {
        public Client GenerateNewValidClient()
        {
            var gender = new Faker().PickRandom<Name.Gender>();

            var client = new Faker<Client>("en_US")
                .CustomInstantiator(c => new Client(
                    Guid.NewGuid(),
                    c.Name.FirstName(gender),
                    c.Name.LastName(gender),
                    c.Date.Past(80, DateTime.Now.AddYears(-18)),
                    string.Empty,
                    true))
                .RuleFor(c => c.Email, (f, c) => f.Internet.Email(c.FirstName.ToLower(), c.LasName.ToLower()));

            return client;
        }

        public Client GenerateNewNotValidClient()
        {
            var gender = new Faker().PickRandom<Name.Gender>();

            var client = new Faker<Client>("en_US")
                .CustomInstantiator(c => new Client(
                    Guid.NewGuid(),
                    c.Name.FirstName(gender),
                    c.Name.LastName(gender),
                    c.Date.Past(1, DateTime.Now.AddYears(-1)),
                    string.Empty,
                    false))
                .RuleFor(c => c.Email, (f, c) => f.Internet.Email(c.FirstName.ToLower(), c.LasName.ToLower()));

            return client;
        }

        [Fact(DisplayName = "New client valid")]
        [Trait("Category", "Client trait")]
        public void Client_NewClient_IsValid()
        {
            // Arrange
            var client = GenerateNewValidClient();

            // Act
            var result = client.IsValid();

            // Assert
            Assert.True(result);
            Assert.Equal(0, client.ValidationResult.Errors.Count);
        }

        [Fact(DisplayName = "New client not valid")]
        [Trait("Category", "Client trait")]
        public void Client_NewClient_IsNotValid()
        {
            // Arrange
            var client = GenerateNewNotValidClient();

            // Act
            var result = client.IsValid();

            // Assert
            Assert.False(result);
            Assert.True(client.ValidationResult.Errors.Count > 0);
        }
    }
}
