using System;

namespace SQLRunManager.Models
{
    public interface IModel
    {
        int Id { get; set; }

        int CreaterId { get; set; }

        DateTime Created { get; set; }
    }
}