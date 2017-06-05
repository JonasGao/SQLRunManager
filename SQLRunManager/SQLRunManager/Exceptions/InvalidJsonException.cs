using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQLRunManager.Exceptions
{
    public class InvalidJsonException : BadRequestException
    {
        public InvalidJsonException(string message) : base(message)
        {
        }
    }
}
