using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookEventManager.DAL;
using DAL;
using DAL.Domain;
using DAL.InterfaceRepo;
using DAL.Repositories;
using DAL.UnitOfWork;
using Shared_Library;
using Shared_Library.Interface;

namespace BLL
{
    public class BusinessLogicBook : IBusinessBook
    {
        DatabaseContext context;
        IBookRepo book;
       
        public BusinessLogicBook(IBookRepo _book)
        {
            
           book = _book;

        }

        public List<BookDTO> GetAllList(int UserID)
        {
            List<BookDTO> convertedlist = new List<BookDTO>();
            List<BookReadingEvent> list = new List<BookReadingEvent>();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<BookReadingEvent, BookDTO>());
            var mapper = config.CreateMapper();
            list = book.Find(book => book.UserID == UserID).ToList();
            convertedlist = mapper.Map<List<BookReadingEvent>, List<BookDTO>>(list);
            return convertedlist;
        }

        public List<BookDTO> GetAll()
        {
            List<BookDTO> convertedlist = new List<BookDTO>();
            List<BookReadingEvent> list = new List<BookReadingEvent>();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<BookReadingEvent, BookDTO>());
            var mapper = config.CreateMapper();
            list = book.GetAll();
            convertedlist = mapper.Map<List<BookReadingEvent>, List<BookDTO>>(list);
            return convertedlist;
        }

        public void InsertBook(BookDTO value)
        {
            BookReadingEvent evt = new BookReadingEvent();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<BookDTO, BookReadingEvent>());
            var mapper = config.CreateMapper();
            evt = mapper.Map<BookDTO, BookReadingEvent>(value);
            evt.CreatedOn = DateTime.Now;
            evt.ModifiedOn = DateTime.Now;
            book.Insert(evt);
           
        }

        public void Update(BookDTO value)
        {
            BookReadingEvent evt = new BookReadingEvent();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<BookDTO, BookReadingEvent>());
            var mapper = config.CreateMapper();
            evt = mapper.Map<BookDTO, BookReadingEvent>(value);
            evt.CreatedOn = DateTime.Now;
            evt.ModifiedOn = DateTime.Now;
            book.Update(evt);

        }

        public void DeleteBook(int id)
        {
            book.Delete(id);
         }


    }
}
