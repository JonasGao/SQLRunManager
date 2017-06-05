﻿namespace SQLRunManager.Models
{
    /// <summary>
    ///     数据库类型，及其默认配置
    /// </summary>
    public class DatabaseType : Model
    {
        public string Title { get; set; }
        public string Server { get; set; }
        public uint Port { get; set; }
        public string Uid { get; set; }
        public string Pwd { get; set; }
    }
}