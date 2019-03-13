using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BookEventManager.DAL;
using DAL.Repository;

namespace DAL.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {

        private DatabaseContext context;
        private DbSet<T> dbSet;

        public BaseRepository(DatabaseContext context)
        {
            
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public void Delete(int id)
        {
            T entityToDelete = dbSet.Find(id);
            Delete(id);
        }

        public List<T> GetAll()
        {
            return dbSet.ToList();
        }

        public T GetObjectByID(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Where(predicate);
        }

        public void Insert(T value)
        {
            dbSet.Add(value);
        }

        public void Update(T obj)
        {
            
            dbSet.Attach(obj);
            context.Entry(obj).State = EntityState.Modified;
        }
    }
}
