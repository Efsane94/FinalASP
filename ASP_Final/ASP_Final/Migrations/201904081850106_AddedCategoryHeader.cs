namespace ASP_Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCategoryHeader : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoryPageHeaders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 100),
                        Image = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Images", "Name", c => c.String(maxLength: 300));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Images", "Name", c => c.String(nullable: false, maxLength: 300));
            DropTable("dbo.CategoryPageHeaders");
        }
    }
}
