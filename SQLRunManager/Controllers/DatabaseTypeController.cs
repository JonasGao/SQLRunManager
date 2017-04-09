using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SQLRunManager.Models;
using SQLRunManager.Services;

namespace SQLRunManager.Controllers
{
    [Route("/api/[controller]")]
    public class DatabaseTypeController : MyBaseController
    {
        public DatabaseTypeController(DatabaseTypeService databaseTypeService)
        {
            DatabaseTypeService = databaseTypeService;
        }

        public DatabaseTypeService DatabaseTypeService { get; }

        [HttpGet]
        public IEnumerable<DatabaseType> Get()
        {
            return DatabaseTypeService.Select();
        }

        [HttpPost]
        public DatabaseType Post([FromBody] DatabaseType databaseType)
        {
            RequireNonNull(databaseType);
            DatabaseTypeService.Insert(databaseType);
            return databaseType;
        }

        [HttpPut]
        public void Put([FromBody] DatabaseType databaseType)
        {
            RequireNonNull(databaseType);
            DatabaseTypeService.Update(databaseType);
        }
    }
}