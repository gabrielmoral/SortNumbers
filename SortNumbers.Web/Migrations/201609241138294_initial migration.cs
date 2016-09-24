namespace SortNumbers.Web.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class initialmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderedElements",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Numbers = c.String(nullable: false),
                    SortType = c.Int(nullable: false),
                    SortDuration = c.Time(nullable: false, precision: 7),
                })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.OrderedElements");
        }
    }
}