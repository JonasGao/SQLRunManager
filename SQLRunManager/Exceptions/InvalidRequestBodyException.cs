namespace SQLRunManager.Exceptions
{
    public class InvalidRequestBodyException: BadRequestException
    {
        public InvalidRequestBodyException() : base("请求的主题内容错误，不是有效的内容")
        {
        }
    }
}
