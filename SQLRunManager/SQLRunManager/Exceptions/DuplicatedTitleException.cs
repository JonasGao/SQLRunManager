namespace SQLRunManager.Exceptions
{
    public class DuplicatedTitleException : BadRequestException
    {
        internal DuplicatedTitleException() : base("标题已存在")
        {
        }
    }
}
