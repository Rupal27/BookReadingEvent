using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL.Domain;
using Shared_Library.Interface;


namespace Shared_Library.Interface
{
    public interface IUserRepo: IRepository<User>
    { 
    }
}
