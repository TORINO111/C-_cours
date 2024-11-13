using Cours.Models;

namespace Cours.Service
{
    public interface IClientService
    {
        List<Client> FindAll();
        Client FindById(int id);
        void Save(Client client);
        void Delete(int id);
        void Update(Client client);

        Client? FindBySurname(string surnom);
       

    }
}