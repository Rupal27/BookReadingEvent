using DAL.Domain;

using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace BookEventManager.DAL
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext() : base("Database")
        {
        }

        public DbSet<BookReadingEvent> BookReadingEvents { get; set; }
        public DbSet<User> Users { get; set; }
       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}