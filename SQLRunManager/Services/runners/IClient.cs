using SQLRunManager.Models;

namespace SQLRunManager.Services.runners
{
    public interface IClient
    {
        DatabaseItem DatabaseItem { get; }

        int ExecuteNonQuery(SqlItem sql);
    }

    public interface IClientBuilder<out T> where T: IClient
    {
        string Type { get; }

        T Build(DatabaseItem databaseItem);
    }
}
