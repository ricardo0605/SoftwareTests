using Feature.Clients;
using System;
using Xunit;

namespace Feature.Tests._02___Fixtures
{
    /// <summary>
    /// Remains the same for all tests. 
    /// If an In-Memory database is nedded, here is a good place to start it.
    /// </summary>
    [CollectionDefinition(nameof(ClientCollection))]
    public class ClientCollection : ICollectionFixture<ClientFixture>
    {
    }

    public class ClientFixture : IDisposable
    {
        public Client GenerateNewValidClient()
        {
            return new Client(Guid.NewGuid(),
                "Ricardo",
                "Pires",
                DateTime.Now.AddYears(-30),
                "ricardo.pires@gmail.com",
                true
            );
        }

        public Client GenerateNewNotValidClient()
        {
            return new Client(
                new System.Guid(),
                string.Empty,
                string.Empty,
                DateTime.Now,
                "ricardo.pires.com",
                true
            );
        }

        public void Dispose()
        {
        }
    }
}
