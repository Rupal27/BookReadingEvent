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

namespace BALUser
{
    public class BusinessLogicUser : IBusinessUser
    {
        DatabaseContext context;
        IUserRepo user;

        UoWUser unit;

        public BusinessLogicUser(IUserRepo _user)
        {
            
            user = _user;


        }



        public void InsertUser(CreateUserDTO value)
        {
            User evt = new User();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CreateUserDTO, User>());
            var mapper = config.CreateMapper();
            evt = mapper.Map<CreateUserDTO, User>(value);
            evt.CreatedOn = DateTime.Now;
            evt.ModifiedOn = DateTime.Now;
            user.Insert(evt);
            
        }

        public void DeleteUser(int id)
        {
            user.Delete(id);
            
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

            var lists = user.Find(temp => (temp.Email == evt.Email && temp.Password == evt.Password)).ToList();
            if (lists.Count != 0)
            {
                loginedUser.Email = lists[0].Email;
                loginedUser.UserID = lists[0].ID;
            }
            else
            {
                loginedUser = null;
            }
            return loginedUser;
        }

    }
}
