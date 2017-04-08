using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQLRunManager.Models
{
    /// <summary>
    /// 数据库配置项
    /// </summary>
    public class DatabaseItem : DatabaseType
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        public string ConnectionString { get; set; }
    }
}
