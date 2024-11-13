using MySql.Data.MySqlClient;

namespace Cours.Core
{
    public class DataBaseConnection : IDataAcess
    {
        protected MySqlConnection? conn;
        private readonly string mysqlConnectionString = "Server=localhost;Port=3306;Database=gestion_dette_symfony_ism;User ID=root;Password=localhost;";
        public void closeConnection()
        {
            if (conn != null && conn.State != System.Data.ConnectionState.Open)
            {
                conn.Close();
                conn = null;
            }
        }

        public MySqlConnection getConnection()
        {
            if (conn == null || conn.State == System.Data.ConnectionState.Closed)
            {
                conn = new MySqlConnection(mysqlConnectionString);
                conn.Open();
            }
            return conn;
        }
    }
}