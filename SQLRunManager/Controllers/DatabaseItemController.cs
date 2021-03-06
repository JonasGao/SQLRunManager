﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SQLRunManager.Models;
using SQLRunManager.Services;

namespace SQLRunManager.Controllers
{
    [Route("api/[controller]")]
    public class DatabaseItemController : MyBaseController
    {
        public DatabaseItemController(DatabaseItemService databaseItemService)
        {
            DatabaseItemService = databaseItemService;
        }

        private DatabaseItemService DatabaseItemService { get; }

        [HttpGet]
        public IEnumerable<SafeDatabaseItem> Get()
        {
            // 不能暴露密码
            return DatabaseItemService.Select().Select(i => new SafeDatabaseItem(i));
        }

        [HttpPost]
        public DatabaseItem Post([FromBody] DatabaseItem databaseItem)
        {
            RequireNonNull(databaseItem);
            DatabaseItemService.Insert(databaseItem);
            return databaseItem;
        }

        [HttpPut]
        public void Put([FromBody] DatabaseItem databaseItem)
        {
            RequireNonNull(databaseItem);
            DatabaseItemService.Update(databaseItem);
        }

        [HttpDelete]
        public void Delete([FromBody] DatabaseItem databaseItem)
        {
            RequireNonNull(databaseItem);
            DatabaseItemService.Delete(databaseItem);
        }
    }
}