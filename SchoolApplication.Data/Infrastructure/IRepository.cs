using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SchoolApplication.Data.Infrastructure
{
    public interface IRepository<T> where T: class
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T Get(Expression<Func<T, bool>> where);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
    }
}
