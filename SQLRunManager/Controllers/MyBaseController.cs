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
                throw new InvalidRequestBodyException();
        }

        public void RequireFieldNonBlank(string content, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new InvalidJsonException($"参数字段 {fieldName} 不能为空");
        }
    }
}