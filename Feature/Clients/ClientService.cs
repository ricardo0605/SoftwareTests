using MediatR;
using System.Collections.Generic;
using System.Linq;

namespace Feature.Clients
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repository;
        private readonly IMediator _mediator;

        public ClientService(IClientRepository repository,
                             IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public IEnumerable<Client> GetAll()
        {
            return _repository.GetAll().Where(c => c.IsActive);
        }

        public void Add(Client client)
        {
            if (!client.IsValid())
                return;

            _repository.Add(client);
            _mediator.Publish(new ClientEmailNotification("contato@xpto.com", client.Email, "Successfully added", "xpto"));
        }

        public void Update(Client client)
        {
            if (!client.IsValid())
                return;

            _repository.Update(client);
            _mediator.Publish(new ClientEmailNotification("contato@xpto.com", client.Email, "Successfully updated", "xpto"));
        }

        public void Inactivate(Client client)
        {
            if (!client.IsValid())
                return;

            client.Inactivate();
            _repository.Update(client);
            _mediator.Publish(new ClientEmailNotification("contato@xpto.com", client.Email, "Successfully inactiveted", "xpto"));
        }

        public void Remove(Client client)
        {
            if (!client.IsValid())
                return;

            _repository.Remove(client.Id);
            _mediator.Publish(new ClientEmailNotification("contato@xpto.com", client.Email, "Successfully removed", "xpto"));
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
