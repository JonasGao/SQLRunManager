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
    }
}