using System;
using Microsoft.AspNetCore.Mvc;
using SQLRunManager.Models;
using SQLRunManager.Services;
using SQLRunManager.Services.Runners;

namespace SQLRunManager.Controllers
{
    [Route("/api/[controller]")]
    public class SqlController: MyBaseController
    {
        public SqlController(SqlService sqlService, DatabaseItemService databaseItemService)
        {
            SqlService = sqlService;
            DatabaseItemService = databaseItemService;
        }

        private SqlService SqlService { get; }
        private DatabaseItemService DatabaseItemService { get; }

        [HttpPost]
        public SqlItem CreateItem([FromBody] SqlItem sqlItem)
        {
            RequireNonNull(sqlItem);
            RequireFieldNonBlank(sqlItem.Content, nameof(sqlItem.Content));
            // TODO
            // 暂时没开始做用户登录之类的管理功能
            // 所以创建人这里暂时不实现
            SqlService.Insert(sqlItem);
            return sqlItem;
        }

        [HttpPost("/{id}")]
        public SqlItem RunItem([FromRoute] int id)
        {
            var sqlItem = SqlService.SelectOne(id);
            var databaseItem = DatabaseItemService.SelectOne(sqlItem.DatabaseId);
            var client = ClientFactory.GetClient(databaseItem);
            client.ExecuteNonQuery(sqlItem);
            sqlItem.Ran = DateTime.Now;
            return sqlItem;
        }
    }
}
