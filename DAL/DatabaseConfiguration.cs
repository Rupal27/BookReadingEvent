using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;
using System.Data.Entity.SqlServer;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared_Library.Logging;

namespace DAL
{
   public class DatabaseConfiguration : DbConfiguration
    {
        public DatabaseConfiguration()
        {
            DbInterception.Add(new DbInterceptorLogging());
        }   
    }
}
