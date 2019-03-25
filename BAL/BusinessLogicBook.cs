using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookEventManager.DAL;
using DAL;
using DAL.Domain;
using DAL.Repositories;
using DAL.UnitOfWork;
using Shared_Library;
using Shared_Library.Interface;

namespace BLL
{
    public class BusinessLogicBook : IBusinessBook
    {
        DatabaseContext context;
       
        UoWBook book;

        public BusinessLogicBook()
        {
            context = new DatabaseContext();
           
             book = new UoWBook(context);

        }

        public List<BookDTO> GetAllList(int UserID)
        {
            List<BookDTO> convertedlist = new List<BookDTO>();
            List<BookReadingEvent> list = new List<BookReadingEvent>();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<BookReadingEvent, BookDTO>());
            var mapper = config.CreateMapper();
            list = book.BookRepository.Find(book=>book.UserID==UserID).ToList();
            convertedlist = mapper.Map<List<BookReadingEvent>, List<BookDTO>>(list);
            return convertedlist;
        }

        public List<BookDTO> GetAll()
        {
            List<BookDTO> convertedlist = new List<BookDTO>();
            List<BookReadingEvent> list = new List<BookReadingEvent>();
            var config = new MapperConfiguration(cfg => cfg.CreateMap< BookReadingEvent ,BookDTO>());
            var mapper = config.CreateMapper();
            list = book.BookRepository.GetAll();
            convertedlist = mapper.Map< List<BookReadingEvent>, List<BookDTO>>(list);
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
            book.BookRepository.Insert(evt);
            book.Save();
        }

        public void Update(BookDTO value)
        {
            BookReadingEvent evt = new BookReadingEvent();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<BookDTO, BookReadingEvent>());
            var mapper = config.CreateMapper();
            evt = mapper.Map<BookDTO, BookReadingEvent>(value);
            evt.CreatedOn = DateTime.Now;
            evt.ModifiedOn = DateTime.Now;
            book.BookRepository.Update(evt);
           
            book.Save();
        }

        public void DeleteBook(int id)
        {
            book.BookRepository.Delete(id);
            book.Save();
        }


    }
}
