using SortNumbers.Web.Migrations;
using System.Data.Entity;

namespace SortNumbers.Web.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("name=DatabaseContext")
        {
            Database.SetInitializer<DatabaseContext>(new MigrateDatabaseToLatestVersion<DatabaseContext, Configuration>());
        }

        public DbSet<OrderedElement> OrderedElements { get; set; }
    }
}