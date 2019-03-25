using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared_Library.Interface
{
   public interface IBusinessUser
    {
        void InsertUser(CreateUserDTO value);
        void DeleteUser(int id);
        LoginUserDTO LoginUser(LoginUserDTO login);
    }
}
