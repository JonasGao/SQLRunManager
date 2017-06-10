using SQLRunManager.Models;

namespace SQLRunManager.Services.runners
{
    public interface IClient
    {
        string Name { get; }

        DatabaseItem DatabaseItem { get; set; }

        int ExecuteNonQuery(SqlItem sql);
    }
}
