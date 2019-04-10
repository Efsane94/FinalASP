namespace ASP_Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAboutFeatured : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AboutFeatureds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Content = c.String(nullable: false, maxLength: 300),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AboutFeatureds");
        }
    }
}
