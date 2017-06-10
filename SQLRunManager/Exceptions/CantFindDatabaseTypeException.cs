namespace SQLRunManager.Exceptions
{
    public class CantFindDatabaseTypeException: BadRequestException
    {
        public CantFindDatabaseTypeException() : base("没有找到对应的数据库类型")
        {
        }
    }
}
