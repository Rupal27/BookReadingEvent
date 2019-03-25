using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookEventManager.DAL;
using DAL.Domain;
using DAL.InterfaceRepo;
using DAL.UnitOfWork;
using Shared_Library.Interface;

namespace DAL.Repositories
{
    public class BookRepository : BaseRepository<BookReadingEvent>, IBookRepo
    {
       
       
        public BookRepository(IUnitofWork unit):base(unit)
        {
            _unitofwork = unit;
        }


    }
}
