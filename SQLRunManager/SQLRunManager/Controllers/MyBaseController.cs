using System;
using Microsoft.AspNetCore.Mvc;
using SQLRunManager.Exceptions;

namespace SQLRunManager.Controllers
{
    public abstract class MyBaseController : Controller
    {
        public void RequireNonNull(object formBody)
        {
            if (formBody == null)
                throw new InvalidJsonTypeException();
        }

        public class InvalidJsonTypeException : BadRequestException
        {
            public InvalidJsonTypeException() : base("参数（或其属性）类型错误")
            {
            }
        }
    }
}