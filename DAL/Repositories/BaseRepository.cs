using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Shared_Library.Interface;
using System.Threading.Tasks;
using BookEventManager.DAL;


namespace DAL.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        public IUnitofWork _unitofwork;
        
        public DbSet<T> dbSet;

        public BaseRepository(IUnitofWork unit)
            {
               _unitofwork=unit;
                dbSet = unit.Db.Set<T>();
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
            return dbSet.Where(predicate);
        }

        public void Insert(T value)
        {
            dbSet.Add(value);
            _unitofwork.Save();
        }

        public void Update(T obj)
        {
            
            dbSet.Attach(obj);
            _unitofwork.Db.Entry(obj).State = EntityState.Modified;
            _unitofwork.Save();
        }
    }
}
