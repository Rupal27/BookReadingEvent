using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Domain;
using Shared_Library.Interface;

namespace DAL.InterfaceRepo
{
    public interface IBookRepo : IRepository<BookReadingEvent>
    {
    }
}
