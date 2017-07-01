using System;

namespace SQLRunManager.Models
{
    /// <summary>
    /// SQL 运行记录
    /// </summary>
    public class SqlItem : Model
    {
        public int DatabaseId { get; set; }

        /// <summary>
        /// 运行内容（SQL语句）
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 受影响的行数
        /// </summary>
        public int? RecordsAffected { get; set; }

        /// <summary>
        /// 运行时间
        /// </summary>
        public DateTime? Ran { get; set; }

        /// <summary>
        /// 运行人
        /// </summary>
        public int? Runner { get; set; }

        public string Exception { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
    }
}
