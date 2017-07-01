using System;
using System.Linq;
using Google.Protobuf.WellKnownTypes;
using SQLRunManager.Context;
using SQLRunManager.Models;
using SQLRunManager.Services;
using SQLRunManager.Services.Runners;
using Xunit;

namespace SQLRunManager.Test
{
    public class RunOneSqlTest
    {
        public RunOneSqlTest()
        {
            DataBase.Configure();
            DatabaseItemService = new DatabaseItemService();
            SqlService = new SqlService(DatabaseItemService);
            UserService = new UserService();
        }

        public DatabaseItemService DatabaseItemService { get; }
        public SqlService SqlService { get; }
        public UserService UserService { get; }

        [Fact]
        public void Test1()
        {
            var user = new User
            {
                Email = "me@jonas.com",
                NickName = "Jonas",
                Password = "123456",
                Created = DateTime.Now,
                CreaterId = -1
            };

            var userExample = user;
            var users = UserService.Select(u => u.Email == userExample.Email).ToList();
            if (users.Any())
            {
                user = users.First();
            }
            else
            {
                UserService.Insert(user);
            }

            var databaseItem = new DatabaseItem
            {
                Title = "Test Server",
                Type = MySqlClientBuilder.ForType,
                Server = "localhost",
                Port = 3306,
                DatabaseName = "test",
                Uid = "root",
                Pwd = "",
                Removed = false,
                CreaterId = user.Id,
                Created = DateTime.Now
            };

            var example = databaseItem;
            var databaseItems = DatabaseItemService.Select(item => item.DatabaseName == example.DatabaseName).ToList();

            if (databaseItems.Any())
            {
                databaseItem = databaseItems.First();
            }
            else
            {
                DatabaseItemService.Insert(databaseItem);
            }

            var sql = new SqlItem
            {
                DatabaseId = databaseItem.Id,
                Content = "INSERT INTO test.table1 (c1, c2, c3, c4) VALUES ('Hello', 'World', 0, '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") +
                          "');",
                CreaterId = user.Id,
                Created = DateTime.Now
            };

            SqlService.Insert(sql);

            SqlService.Run(sql, user);
        }
    }
}