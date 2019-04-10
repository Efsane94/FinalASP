namespace ASP_Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFurnitures1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Images", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Images", "MyProperty", c => c.Int(nullable: false));
        }
    }
}
