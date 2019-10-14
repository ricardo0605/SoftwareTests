using System;
using System.Collections.Generic;

namespace Feature.Clients
{
    public interface IClientService : IDisposable
    {
        IEnumerable<Client> GetAll();
        void Add(Client client);
        void Update(Client client);
        void Remove(Client client);
        void Inactivate(Client client);
    }
}
