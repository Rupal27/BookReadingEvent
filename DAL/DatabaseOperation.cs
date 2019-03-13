using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared_Library;
using AutoMapper;
using DAL.Domain;

namespace BookEventManager.DAL
{
    public class DatabaseOperation
    {
        public DatabaseContext db = new DatabaseContext();


        public void SubmitValues(BookDTO book)
        {
            BookReadingEvent evt = new BookReadingEvent();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<BookDTO, BookReadingEvent>());
            var mapper = config.CreateMapper();
            evt = mapper.Map<BookDTO, BookReadingEvent>(book);
            db.BookReadingEvents.Add(evt);
            db.SaveChanges();
            return;
        }

        public void RegisterValues(CreateUserDTO user)
        {
            User value = new User();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CreateUserDTO, User>());
            var mapper = config.CreateMapper();
            value = mapper.Map<CreateUserDTO, User>(user);
            db.Users.Add(value);
            db.SaveChanges();
            return;
        }

        
        public List<BookDTO> ViewEvent()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<BookReadingEvent, BookDTO>());
            var mapper = config.CreateMapper();
            List<BookDTO> dtoList = new List<BookDTO>();
            List<BookReadingEvent> objectlist = new List<BookReadingEvent>();
            objectlist= (from x in db.BookReadingEvents select x).ToList();

            dtoList = mapper.Map<List<BookReadingEvent>,List<BookDTO>>(objectlist);
            return dtoList;
        }
        
    }
}
