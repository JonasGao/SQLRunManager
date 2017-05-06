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
        private static string _connectionString;

        private static string ConnectionString
        {
            get
            {
                if (IsNullOrWhiteSpace(_connectionString))
                    _connectionString = new MySqlConnectionStringBuilder
                        {
                            Database = "sql_manager",
                            Server = "localhost",
                            UserID = "root",
                            Password = "1234"
                        }
                        .GetConnectionString(true);

                return _connectionString;
            }
        }

        internal static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
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
            DefaultTypeMap.MatchNamesWithUnderscores = true;
        }

        public class UnderscoreTableNameResolver : DommelMapper.ITableNameResolver
        {
            public string ResolveTableName(Type type)
            {
                var name = type.Name;
                if (type.GetTypeInfo().IsInterface && name.StartsWith("I"))
                    name = name.Substring(1);

                return ConvertCamelcaseToUnderscore(name);
            }

            private static string ConvertCamelcaseToUnderscore(string inputString)
            {
                return Concat(inputString.Select(
                    (x, j) => j > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString()));
            }
        }
    }
}