
using Cours.Models;

namespace Cours.Repository.Impl
{

    public class ClientRepositoryListImpl : IClientRepository
    {
        
        private readonly List<Client> clients = new List<Client>();

        public List<Client> SelectAll()
        {
            return clients;
        }
        public Client? SelectById(int id)
        {
            foreach (var client in clients)
            {
                if (client.Id == id)
                    return client;
            }
            return null;
        }
        public void Insert(Client client)
        {
            clients.Add(client);
        }
        public void Update(Client client)
        {
            int position = clients.FindIndex(cl => cl.Id == client.Id);
            if (position != -1)
                clients[position] = client;
        }
        public void Delete(int id)
        {
            Client clientToRemove = clients.Find(cl => cl.Id == id)!;
            if (clientToRemove != null)
                clients.Remove(clientToRemove);
        }

        public Client? FindBySurname(string surname)
        {
            return clients.Find(cl => cl.Surnom.ToLower() == surname.ToLower());
        }
    }
}