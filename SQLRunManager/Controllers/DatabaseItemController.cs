using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SQLRunManager.Models;
using SQLRunManager.Services;

namespace SQLRunManager.Controllers
{
    [Route("api/[controller]")]
    public class DatabaseItemController : Controller
    {
        private DatabaseItemService DatabaseItemService { get; }

        public DatabaseItemController(DatabaseItemService databaseItemService)
        {
            DatabaseItemService = databaseItemService;
        }

        [HttpGet]
        public IEnumerable<DatabaseItem> Get()
        {
            return DatabaseItemService.Select();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public DatabaseItem Get(int id)
        {
            return DatabaseItemService.SelectOne(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            DatabaseItemService.Delete(new DatabaseItem{Id = id});
        }
    }
}
