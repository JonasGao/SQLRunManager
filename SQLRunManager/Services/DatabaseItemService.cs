using System.Linq;
using SQLRunManager.Exceptions;
using SQLRunManager.Models;
using SQLRunManager.Services.runners;

namespace SQLRunManager.Services
{
    public class DatabaseItemService : AbstractDataService<DatabaseItem>
    {
        public new void Insert(DatabaseItem model)
        {
            RequireUniqueTitle(model);
            RegistedDatabaseType(model);
            base.Insert(model);
        }

        public new void Update(DatabaseItem model)
        {
            RequireUniqueTitle(model);
            RegistedDatabaseType(model);
            base.Update(model);
        }

        /// <summary>
        ///     不进行实际的删除，只进行逻辑删除。因为数据库的执行记录需要进行保留
        /// </summary>
        public new void Delete(DatabaseItem databaseItem)
        {
            databaseItem.Removed = true;
            Update(databaseItem);
        }

        public void RequireUniqueTitle(DatabaseItem databaseItem)
        {
            if (Select(it => it.Title == databaseItem.Title && it.Id != databaseItem.Id).Any())
                throw new DuplicatedTitleException();
        }

        public void RegistedDatabaseType(DatabaseItem databaseItem)
        {
            if (!ClientFactory.HasClient(databaseItem))
                throw new CantFindDatabaseTypeException();
        }
    }
}