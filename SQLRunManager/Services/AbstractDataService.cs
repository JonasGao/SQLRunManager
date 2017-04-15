using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Dommel;
using SQLRunManager.Context;
using SQLRunManager.Models;

namespace SQLRunManager.Services
{
    public abstract class AbstractDataService<T> where T : Model
    {
        public void Insert(T model)
        {
            DataBase.Run(db => model.Id = db.Insert(model) as int? ?? 0);
        }

        public void Delete(T model)
        {
            DataBase.Run(db => db.Delete(model));
        }

        public void Update(T model)
        {
            DataBase.Run(db => db.Update(model));
        }

        public T SelectOne(int id)
        {
            return DataBase.Run(db => db.Get<T>(id));
        }

        public IEnumerable<T> Select()
        {
            return DataBase.Run(db => db.GetAll<T>());
        }

        public IEnumerable<T> Select(Expression<Func<T, bool>> pre)
        {
            return DataBase.Run(db => db.Select(pre));
        }
    }
}