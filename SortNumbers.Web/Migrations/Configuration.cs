namespace SortNumbers.Web.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<SortNumbers.Web.Models.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SortNumbers.Web.Models.DatabaseContext context)
        {
        }
    }
}