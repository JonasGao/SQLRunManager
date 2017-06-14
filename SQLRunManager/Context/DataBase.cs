using System;
using System.Data;
using System.Linq;
using System.Reflection;
using Dapper;
using Dommel;
using MySql.Data.MySqlClient;
using static System.String;

namespace SQLRunManager.Context
{
    public class DataBase
    {
        private static readonly Lazy<string> ConnectionString = new Lazy<string>(() => new MySqlConnectionStringBuilder
            {
                Database = "sql_manager",
                Server = "localhost",
                UserID = "root",
                Password = ""
            }
            .GetConnectionString(true));

        private static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString.Value);
        }

        internal static void Run(Action<IDbConnection> action)
        {
            using (IDbConnection iDbConnection = GetConnection())
            {
                action(iDbConnection);
            }
        }

        internal static T Run<T>(Func<IDbConnection, T> func)
        {
            using (IDbConnection iDbConnection = GetConnection())
            {
                return func(iDbConnection);
            }
        }

        public static void Configure()
        {
            DommelMapper.SetTableNameResolver(new UnderscoreTableNameResolver());
            DommelMapper.SetColumnNameResolver(new UnderscoreColumnNameResolver());
            DefaultTypeMap.MatchNamesWithUnderscores = true;
        }

        /// <summary>
        /// 数据库表名的驼峰写法转下划线写法
        /// </summary>
        public class UnderscoreTableNameResolver : DommelMapper.ITableNameResolver
        {
            public string ResolveTableName(Type type)
            {
                var name = type.Name;
                if (type.GetTypeInfo().IsInterface && name.StartsWith("I"))
                    name = name.Substring(1);

                return ConvertCamelcaseToUnderscore(name);
            }
        }

        public class UnderscoreColumnNameResolver : DommelMapper.IColumnNameResolver
        {
            public string ResolveColumnName(PropertyInfo propertyInfo)
            {
                return ConvertCamelcaseToUnderscore(propertyInfo.Name);
            }
        }

        private static string ConvertCamelcaseToUnderscore(string inputString)
        {
            return Concat(inputString.Select(
                (x, j) => j > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString()));
        }
    }
}