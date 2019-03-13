using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookEventManager.DAL;
using DAL.Domain;
using DAL.Repository;
using Shared_Library.Interface;

namespace DAL.Repositories
{
    public class BookRepository : BaseRepository<BookReadingEvent>, IBookRepo
    {
        private DatabaseContext context;
        
        public BookRepository(DatabaseContext context): base(context)
        {
            this.context = context;
        }

               
    }
}
