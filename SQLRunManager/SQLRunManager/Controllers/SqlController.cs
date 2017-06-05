using Microsoft.AspNetCore.Mvc;
using SQLRunManager.Models;
using SQLRunManager.Services;

namespace SQLRunManager.Controllers
{
    [Route("/api/[controller]")]
    public class SqlController: MyBaseController
    {
        public SqlController(SqlService sqlService)
        {
            SqlService = sqlService;
        }

        private SqlService SqlService { get; }

        [HttpPost]
        public SqlItem CreateItem([FromBody] SqlItem sqlItem)
        {
            RequireNonNull(sqlItem);
            RequireFieldNonBlank(sqlItem.Content, nameof(sqlItem.Content));
            // 暂时开始没开始做用户登录之类的管理功能
            // 所以创建人这里暂时不实现

            SqlService.Insert(sqlItem);
            return sqlItem;
        }

        [HttpPost("/{id}")]
        public SqlItem RunItem([FromRoute] int id)
        {
            var sqlItem = SqlService.SelectOne(id);
            
            return sqlItem;
        }
    }
}
