using MySql.Data.MySqlClient;

namespace SQLRunManager.Models
{
    /// <summary>
    ///     数据库配置项
    /// </summary>
    public class DatabaseItem : Model
    {
        public string Title { get; set; }
        public string Server { get; set; }
        public uint Port { get; set; }
        public string Uid { get; set; }
        public string Pwd { get; set; }
        public string DatabaseName { get; set; }

        /// <summary>
        ///     逻辑删除标志位
        /// </summary>
        public bool Removed { get; set; } = false;

        public string Type { get; set; }

        /// <summary>
        ///     获取当前配置的连接字符串
        /// </summary>
        public string ConnectionString => new MySqlConnectionStringBuilder
        {
            Server = Server,
            Port = Port,
            Database = DatabaseName,
            UserID = Uid,
            Password = Pwd
        }.ConnectionString;
    }

    public class SafeDatabaseItem
    {
        public SafeDatabaseItem(DatabaseItem databaseItem)
        {
            Title = databaseItem.Title;
            Server = databaseItem.Server;
            Port = databaseItem.Port;
            DatabaseName = databaseItem.DatabaseName;
            Uid = databaseItem.Uid;
            Removed = databaseItem.Removed;
            Type = databaseItem.Type;
        }

        public string DatabaseName { get; }
        public string Title { get; }
        public string Server { get; }
        public uint Port { get; }
        public string Uid { get; }
        public bool Removed { get; }
        public string Type { get; }
    }
}