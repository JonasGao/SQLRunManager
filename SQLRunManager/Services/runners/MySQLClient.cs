using System.Collections.Generic;
using MySql.Data.MySqlClient;
using SQLRunManager.Models;

namespace SQLRunManager.Services.Runners
{
    public class MySqlClient: IClient
    {
        public MySqlClient(DatabaseItem databaseItem)
        {
            DatabaseItem = databaseItem;
        }

        public DatabaseItem DatabaseItem { get; }

        public int ExecuteNonQuery(SqlItem sqlItem)
        {
            using (var connection = new MySqlConnection(DatabaseItem.ConnectionString))
            {
                connection.Open();
                using (var command = new MySqlCommand(sqlItem.Content, connection))
                {
                    return (sqlItem.RecordsAffected = command.ExecuteNonQuery()).Value;
                }
            }
        }
    }

    public class MySqlClientBuilder : IClientBuilder<MySqlClient>
    {
        public const string ForType = "MySQL";

        public string Type { get; } = ForType;

        private readonly Dictionary<string, MySqlClient> _mySqlClients = new Dictionary<string, MySqlClient>();

        public MySqlClient Build(DatabaseItem databaseItem)
        {
            var key = databaseItem.ConnectionString;

            if (_mySqlClients.ContainsKey(key))
                return _mySqlClients[key];

            return _mySqlClients[key] = new MySqlClient(databaseItem);
        }
    }
}
