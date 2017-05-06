using System;

namespace SQLRunManager.Models
{
    /// <summary>
    /// SQL 运行记录
    /// </summary>
    public class SqlItem : Model
    {
        /// <summary>
        /// 运行内容（SQL语句）
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 运行时间
        /// </summary>
        public DateTime? Ran { get; set; }

        /// <summary>
        /// 运行人
        /// </summary>
        public string Runner { get; set; }
    }
}
