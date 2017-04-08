using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SQLRunManager.Models;
using SQLRunManager.Services;

namespace SQLRunManager.Controllers
{
    [Route("/api/[controller]")]
    public class DatabaseTypeController : Controller
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
        public void Post([FromBody]DatabaseType databaseType)
        {
            DatabaseTypeService.Insert(databaseType);
        }
    }
}
