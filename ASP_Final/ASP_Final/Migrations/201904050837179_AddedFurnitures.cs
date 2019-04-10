namespace ASP_Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFurnitures : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Furnitures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Price = c.String(nullable: false, maxLength: 100),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 300),
                        FurnitureId = c.Int(nullable: false),
                        MyProperty = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Furnitures", t => t.FurnitureId, cascadeDelete: true)
                .Index(t => t.FurnitureId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "FurnitureId", "dbo.Furnitures");
            DropForeignKey("dbo.Furnitures", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Images", new[] { "FurnitureId" });
            DropIndex("dbo.Furnitures", new[] { "CategoryId" });
            DropTable("dbo.Images");
            DropTable("dbo.Furnitures");
            DropTable("dbo.Categories");
        }
    }
}
