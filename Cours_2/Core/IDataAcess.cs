using MySql.Data.MySqlClient;

namespace Cours.Core
{
    public interface IDataAcess
    {
        MySqlConnection getConnection();
        void closeConnection();
        
    }

    /* 
        db_name : gestion_dette_symfony_ism 
     */
}