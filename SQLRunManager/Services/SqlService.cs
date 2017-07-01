using System;
using SQLRunManager.Exceptions;
using SQLRunManager.Models;
using SQLRunManager.Services.Runners;

namespace SQLRunManager.Services
{
    public class SqlService : AbstractDataService<SqlItem>
    {
        public SqlService(DatabaseItemService databaseItemService)
        {
            DatabaseItemService = databaseItemService;
        }

        private DatabaseItemService DatabaseItemService { get; }

        public void Run(SqlItem sql, User user)
        {
            var databaseItem = DatabaseItemService.SelectOne(sql.DatabaseId);
            if (databaseItem == null)
                throw new DatabaseNotFoundException(sql.DatabaseId);

            try
            {
                var recordsAffected = ClientFactory.GetClient(databaseItem).ExecuteNonQuery(sql);
                sql.RecordsAffected = recordsAffected;
            }
            catch (Exception e)
            {
                sql.Exception = e.GetType().Name;
                sql.Message = e.Message;
                sql.StackTrace = e.StackTrace;
            }
            
            sql.Runner = user.Id;
            sql.Ran = DateTime.Now;

            Update(sql);
        }
    }
}