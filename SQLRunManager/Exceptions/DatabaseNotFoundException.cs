using System;

namespace SQLRunManager.Exceptions
{
    public class DatabaseNotFoundException : Exception
    {
        public DatabaseNotFoundException(int databaseItemId) : base($"Database not found by your id: {databaseItemId}")
        {
        }
    }
}
