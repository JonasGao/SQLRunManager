using System.Linq;
using SQLRunManager.Exceptions;
using SQLRunManager.Models;

namespace SQLRunManager.Services
{
    public class DatabaseItemService : AbstractDataService<DatabaseItem>
    {
        public new void Insert(DatabaseItem model)
        {
            if (Select(it => it.Title == model.Title).Any())
                throw new DuplicatedTitleException();
            base.Insert(model);
        }

        public new void Update(DatabaseItem model)
        {
            if (Select(it => it.Title == model.Title && it.Id != model.Id).Any())
                throw new DuplicatedTitleException();
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

        public class DuplicatedTitleException : BadRequestException
        {
            internal DuplicatedTitleException() : base("标题已存在")
            {
            }
        }
    }
}