using Cours.Core;
using Cours.Models;

namespace Cours.Repository
{
    public interface IClientRepository : IRepository<Client>
    {
        Client? FindBySurname(String surname);
    }
}