using Cours.Core;
using Cours.Models;
using MySql.Data.MySqlClient;
using Dapper;
using System.Data;

namespace Cours.Repository.Impl
{
    public class ClientRepositoryEntityFrameworkImpl : IClientRepository
    {
        private readonly IDataAcess dataAcess;
        public ClientRepositoryEntityFrameworkImpl(IDataAcess dataAcess)
        {
            this.dataAcess = dataAcess;
        }
    }
}