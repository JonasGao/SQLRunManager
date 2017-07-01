namespace SQLRunManager.Exceptions
{
    public class DatabaseTypeNotFoundException: BadRequestException
    {
        public DatabaseTypeNotFoundException() : base("没有找到对应的数据库类型")
        {
        }
    }
}
