using System.Data.Entity;

namespace CsiMediaProject.Web.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("name=DatabaseContext")
        {
        }

        public DbSet<OrderedElement> OrderedElements { get; set; }
    }
}