using System;

namespace SQLRunManager.Exceptions
{
    public class InvalidJsonTypeException : Exception
    {
        public InvalidJsonTypeException() : base("参数（或其属性）类型错误")
        {
        }
    }
}