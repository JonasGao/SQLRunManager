using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQLRunManager.Models
{
    public class Model : IModel
    {
        /// <summary>
        /// 自增 ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public string Creater { get; set; }
    }
}
