using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;



namespace Shared_Library.Interface
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T GetObjectByID(int ID);
        void Insert(T obj);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        void Delete(int ID);
        void Update(T obj);
             
    }
}
