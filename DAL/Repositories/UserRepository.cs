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
        public class UserRepository : BaseRepository<User>, IUserRepo
        {
            private DatabaseContext context;

            public UserRepository(DatabaseContext context) : base(context)
        {
                this.context = context;
            }
               
        
    }
    }

 
