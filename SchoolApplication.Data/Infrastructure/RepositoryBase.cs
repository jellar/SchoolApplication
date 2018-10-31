using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SchoolApplication.Data.Infrastructure
{
    public abstract class RepositoryBase<T> where T: class
    {

        private readonly IDbSet<T> dbSet;
        private SchoolEntities1 dataContext;

        public RepositoryBase(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
            dbSet = DataContext.Set<T>();
        }

        public IDatabaseFactory DatabaseFactory { get; private set; }

        protected SchoolEntities1 DataContext
        {
            get { return dataContext ?? (dataContext = DatabaseFactory.Get()); }
        }

        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).ToList();
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return dbSet.Find(where);
        }
    }
}
