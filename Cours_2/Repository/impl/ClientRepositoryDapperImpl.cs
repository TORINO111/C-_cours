using Cours.Core;
using Cours.Models;
using MySql.Data.MySqlClient;
using Dapper;
using System.Data;

namespace Cours.Repository.Impl
{
    public class ClientRepositoryDapperImpl : IClientRepository
    {
        private readonly IDataAcess dataAcess;

        public ClientRepositoryDapperImpl(IDataAcess dataAcess)
        {
            this.dataAcess = dataAcess;
        }


        public void Delete(int id)
        {
            using (var conn = dataAcess.getConnection())
            {
                string query = "DELETE FROM client WHERE client.id = @id;";
                int rowsAffected = conn.Execute(query, new { id });

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Client supprimé avec succès!");
                }
                else
                {
                    Console.WriteLine("Client introuvanle.");
                }
            }
        }

        public Client? FindBySurname(string surname)
        {
            using (var conn = dataAcess.getConnection())
            {
                string query = "SELECT * FROM client WHERE surname = @Surnom";

                // Exécuter la requête et récupérer un seul client ou null si non trouvé
                Client? client = conn.QuerySingleOrDefault<Client>(query, new { Surnom = surname });

                return client;
            }
        }

        public void Insert(Client entity)
        {
            using (var conn = dataAcess.getConnection())
            {
                string query = @"INSERT INTO client (surname, telephone, adresse, create_at, update_at) VALUES (@Surnom, @Telephone, @Adresse, @CreateAt, @UpdateAt); SELECT LAST_INSERT_ID();";

                // Exécuter la requête d'insertion et récupérer l'ID généré
                entity.Id = conn.QuerySingle<int>(query, new
                {
                    entity.Surnom,
                    entity.Telephone,
                    entity.Adresse,
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now
                });

                Console.WriteLine("Client added successfully with ID: " + entity.Id);
            }

        }

        public List<Client> SelectAll()
        {
            using (var conn = dataAcess.getConnection())
            {
                string query = "SELECT * FROM client";
                List<Client> clients = conn.Query<Client>(query).AsList();

                return clients;
            }
        }

        public Client? SelectById(int id)
        {
            using (var conn = dataAcess.getConnection())
            {
                string query = "SELECT * FROM client WHERE id = @id";
                Client? client = conn.QuerySingleOrDefault<Client>(query, new { id });

                return client;
            }
        }

        public void Update(Client entity)
        {
            using (var conn = dataAcess.getConnection())
            {
                string query = @"UPDATE client SET adresse = @Adresse, surname = @Surnom,telephone = @Telephone WHERE id = @Id;";

                // Exécuter la requête de mise à jour en passant l'objet entity
                int rowsAffected = conn.Execute(query, new
                {
                    entity.Id,
                    entity.Surnom,
                    entity.Telephone,
                    entity.Adresse
                });

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Client updated successfully.");
                }
                else
                {
                    Console.WriteLine("Client not found or no update needed.");
                }
            }
        }
    }
}