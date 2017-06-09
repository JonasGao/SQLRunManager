using SQLRunManager.Models;

namespace SQLRunManager.Services.runners
{
    public interface IClient
    {
        DatabaseItem DatabaseItem { get; set; }

        int ExecuteNonQuery(SqlItem sql);
    }
}
