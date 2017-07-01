using System;
using SQLRunManager.Context;
using SQLRunManager.Models;
using SQLRunManager.Services;
using SQLRunManager.Services.Runners;
using Xunit;
using Xunit.Sdk;

namespace SQLRunManager.Test
{
    public class UnitTest1
    {
        public UnitTest1()
        {
            DataBase.Configure();
        }

        [Fact]
        public void TestGetClientByDatabaseItem()
        {
            Assert.Equal(ClientFactory.GetClient(new DatabaseItem {Type = "MySQL"}).GetType(), typeof(MySqlClient));
        }
        
        [Fact]
        public void TestColumnResolver()
        {
            var sqlItem = new SqlItem
            {
                DatabaseId = 1,
                Created = DateTime.Now,
                CreaterId = 1,
                Content = "select 1"
            };

            var sqlService = new SqlService(null);
            
            sqlService.Insert(sqlItem);
        }
    }
}