using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookEventManager.DAL;
using DAL.Domain;

using Shared_Library.Interface;

namespace DAL.Repositories
{
        public class UserRepository : BaseRepository<User>, IUserRepo
        {
        
    
        public UserRepository(IUnitofWork unit) : base(unit)
        {
            _unitofwork = unit;
        }


    }
    }

 
