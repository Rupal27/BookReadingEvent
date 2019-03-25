using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared_Library.Interface
{
   public interface IBusinessBook
    {
        List<BookDTO> GetAllList(int UserID);
        List<BookDTO> GetAll();
        void InsertBook(BookDTO value);
        void Update(BookDTO value);
        void DeleteBook(int id);
    }
}
