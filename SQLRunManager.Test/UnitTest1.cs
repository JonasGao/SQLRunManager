using System;
using SQLRunManager.Context;
using SQLRunManager.Models;
using SQLRunManager.Services;
using SQLRunManager.Services.runners;
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
        public void Test1()
        {
            Assert.Equal(ClientFactory.GetClient(new DatabaseItem {Type = "MySQL"}).GetType(), typeof(MySqlClient));
        }

        [Fact]
        public void Test2()
        {
            var sqlItem = new SqlItem
            {
                DatabaseId = 1,
                Created = DateTime.Now,
                CreaterId = 1,
                Content = "select 1"
            };

            var sqlService = new SqlService();
            
            sqlService.Insert(sqlItem);
        }
    }
}