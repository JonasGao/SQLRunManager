using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace SQLRunManager.Models
{
    public interface IModel
    {
        int Id { get; set; }

        string Creater { get; set; }

        DateTime Created { get; set; }
    }
}
