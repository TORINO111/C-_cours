using Cours.Core;
using Cours.Models;
using MySql.Data.MySqlClient;

namespace Cours.Repository
{
    public class ClientRepositoryBdImpl : IClientRepository
    {
        private readonly IDataAcess dataAcess;
        public ClientRepositoryBdImpl(IDataAcess dataAcess)
        {
            this.dataAcess = dataAcess;
        }



        public void Delete(int id)
        {
            using (var conn = dataAcess.getConnection())
            {
                string query = "DELETE FROM client WHERE client.id = @id;";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Client deleted successfully.");
                }
            }

        }

        public Client? FindBySurname(string surname)
        {
            Client? client = null;
            using (var conn = dataAcess.getConnection())
            {

                string query = "SELECT * FROM client WHERE surname = @surnom";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@surnom", surname);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            client = new()
                            {
                                Id = reader.GetInt32("id"),
                                Surnom = reader.GetString("surname"),
                                Telephone = reader.GetString("telephone"),
                                Adresse = reader.GetString("adresse")
                            };
                        }
                    }
                }
            }
            return client;
        }

        public void Insert(Client entity)
        {
            using (var conn = dataAcess.getConnection())
            {
                string query = "INSERT INTO client (surname, telephone, adresse, create_at, update_at) VALUES (@surnom, @telephone, @adresse, @createAt, @updateAt)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))

                {
                    cmd.Parameters.AddWithValue("@surnom", entity.Surnom);
                    cmd.Parameters.AddWithValue("@telephone", entity.Telephone);
                    cmd.Parameters.AddWithValue("@adresse", entity.Adresse);
                    cmd.Parameters.AddWithValue("@createAt", DateTime.Now);
                    cmd.Parameters.AddWithValue("@updateAt", DateTime.Now);
                    cmd.ExecuteNonQuery();
                    entity.Id = (int)cmd.LastInsertedId;
                    Console.WriteLine("Client added successfully.");
                }
            }
        }

        public List<Client> SelectAll()
        {
            List<Client> clients = new List<Client>();
            //MySqlConnection => Connection : Java
            // MySqlCommand => Statement : Java
            // MySqlDataReader => ResultSet : Java
            using (var conn = dataAcess.getConnection())
            {
                string query = "SELECT * FROM client";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            clients.Add(new()
                            {
                                Id = reader.GetInt32("id"),
                                Surnom = reader.GetString("surname"),
                                Telephone = reader.GetString("telephone"),
                                Adresse = reader.GetString("adresse")
                            });
                        }
                    }
                }
            }
            return clients;
        }

        public Client? SelectById(int id)
        {
            Client? client = null;
            using (var conn = dataAcess.getConnection())
            {

                string query = "SELECT * FROM client WHERE id = @id";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            client = new()
                            {
                                Id = reader.GetInt32("id"),
                                Surnom = reader.GetString("surname"),
                                Telephone = reader.GetString("telephone"),
                                Adresse = reader.GetString("adresse")
                            };
                        }
                    }
                }
            }
            return client;
        }

        public void Update(Client entity)
        {
            using (var conn = dataAcess.getConnection())
            {

                string query = "UPDATE client SET adresse = @adresse, surname = @surname, telephone = @telephone WHERE client.id = @id;";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", (Int32)entity.Id);
                    cmd.Parameters.AddWithValue("@surname", entity.Surnom);
                    cmd.Parameters.AddWithValue("@telephone", entity.Telephone);
                    cmd.Parameters.AddWithValue("@adresse", entity.Adresse);
                    // cmd.Parameters.AddWithValue("@updateAt", DateTime.Now); // il doit rester on fait une MAJ
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Client updated successfully.");
                }
            }

        }
    }
}