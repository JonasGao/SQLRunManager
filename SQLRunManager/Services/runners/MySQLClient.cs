using MySql.Data.MySqlClient;
using SQLRunManager.Models;

namespace SQLRunManager.Services.runners
{
    public class MySqlClient: IClient
    {
        public DatabaseItem DatabaseItem { get; set; }

        public int ExecuteNonQuery(SqlItem sqlItem)
        {
            using (var connection = new MySqlConnection(DatabaseItem.ConnectionString))
            {
                connection.Open();
                using (var command = new MySqlCommand(sqlItem.Content))
                {
                    return sqlItem.RecordsAffected = command.ExecuteNonQuery();
                }
            }
        }
    }
}
