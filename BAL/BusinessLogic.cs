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

namespace BAL
{
    public class BusinessLogic
    {
        DatabaseContext context;
        UoWUser user;
        UoWBook book;

        public BusinessLogic()
        {
            context = new DatabaseContext();
             user = new UoWUser(context);
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

        public void InsertUser(CreateUserDTO value)
        {   
            User evt = new User();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CreateUserDTO, User>());
            var mapper = config.CreateMapper();
            evt = mapper.Map<CreateUserDTO, User>(value);
            evt.CreatedOn = DateTime.Now;
            evt.ModifiedOn = DateTime.Now;
            user.UserRepository.Insert(evt);
            user.Save();
        }

        public void DeleteUser(int id)
        {
            user.UserRepository.Delete(id);
            user.Save();
        }


        public LoginUserDTO LoginUser(LoginUserDTO login)
        {
            //bool value;
            User evt = new User();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<LoginUserDTO, User>());
            var mapper = config.CreateMapper();
            evt = mapper.Map<LoginUserDTO, User>(login);
            evt.CreatedOn = DateTime.Now;
            evt.ModifiedOn = DateTime.Now;
            LoginUserDTO loginedUser = new LoginUserDTO();
          
            var lists = user.UserRepository.Find(temp => (temp.Email == evt.Email && temp.Password == evt.Password)).ToList();
            if (lists.Count!=0)
            {
                loginedUser.Email= lists[0].Email;
                loginedUser.UserID=lists[0].ID;
            }
            else
            {
                loginedUser = null;
            }
            return loginedUser;
        }

    }
}
