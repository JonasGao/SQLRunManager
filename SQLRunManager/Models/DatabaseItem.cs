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

        /// <summary>
        ///     逻辑删除标志位
        /// </summary>
        public bool Removed { get; set; } = false;

        public int DatabaseTypeId { get; set; }

        public string Type { get; set; }

        /// <summary>
        ///     获取当前配置的连接字符串
        /// </summary>
        public string ConnectionString => new MySqlConnectionStringBuilder
        {
            Server = Server,
            Port = Port,
            UserID = Uid,
            Password = Pwd
        }.ConnectionString;
    }
}