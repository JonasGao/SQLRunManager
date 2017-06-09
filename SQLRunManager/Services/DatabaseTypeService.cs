using System.Linq;
using SQLRunManager.Exceptions;
using SQLRunManager.Models;

namespace SQLRunManager.Services
{
    public class DatabaseTypeService : AbstractDataService<DatabaseType>
    {
        public new void Insert(DatabaseType model)
        {
            if (Select(it => it.Title == model.Title).Any())
                throw new DuplicatedTitleException();
            base.Insert(model);
        }

        public new void Update(DatabaseType model)
        {
            if (Select(it => it.Title == model.Title && it.Id != model.Id).Any())
                throw new DuplicatedTitleException();
            base.Update(model);
        }
    }
}