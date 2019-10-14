using Xunit;

namespace Feature.Tests._02___Fixtures
{
    [Collection(nameof(ClientCollection))]
    public class ClientFixturesTests
    {
        private readonly ClientFixture _clientFixture;

        public ClientFixturesTests(ClientFixture clientFixture)
        {
            this._clientFixture = clientFixture;
        }

        [Fact(DisplayName = "New client valid")]
        [Trait("Category", "Client trait")]
        public void Client_NewClient_IsValid()
        {
            // Arrange
            var client = _clientFixture.GenerateNewValidClient();

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
            var client = _clientFixture.GenerateNewNotValidClient();

            // Act
            var result = client.IsValid();

            // Assert
            Assert.False(result);
            Assert.NotEqual(0, client.ValidationResult.Errors.Count);
        }
    }
}
