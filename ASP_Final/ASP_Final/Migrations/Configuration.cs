namespace ASP_Final.Migrations
{
    using ASP_Final.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ASP_Final.Identity;
    internal sealed class Configuration : DbMigrationsConfiguration<ASP_Final.DAL.FurnitureContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ASP_Final.DAL.FurnitureContext context)
        {
            context.Header.AddOrUpdate(h => h.Title,
                new Header { Title = "We Create Amazing<br>Architecture Designs", Content= "A small river named Duden flows by their place and supplies it with the necessary regelialia. It is a paradisematic country, in which roasted parts of sentences fly into your mouth.", Image= "banner/bg_2.jpg" }
            
            );

            context.Category.AddOrUpdate(c => c.Name,
            new Category { Name = "Sitting room" },
            new Category { Name = "Bedroom" },
            new Category { Name = "Baby rooms" }

            );

            context.Furniture.AddOrUpdate(f => f.Name,
            new Furniture { Name = "Malpensa Seat Sofa Set", Price = "2000 $", CategoryId = 1 },
            new Furniture { Name = "Vienza Sitting Group", Price = "1800 $", CategoryId = 1 },
            new Furniture { Name = "Mavenna Bedroom Set", Price = "3000 $", CategoryId = 2 },
            new Furniture { Name = "Angel Bedroom Set", Price = "5000 $", CategoryId = 2 },
            new Furniture { Name = "Joyful Baby Room Set", Price = "1000 $", CategoryId = 3 },
            new Furniture { Name = "Portivo Baby Room Set Pink", Price = "1500 $", CategoryId = 3 }

            );

            context.Image.AddOrUpdate(i => i.Name,
                new Image { Name = "furniture/sitting_1.jpg", FurnitureId=1 },
                new Image { Name = "furniture/sitting_12.jpg", FurnitureId=1 },
                new Image { Name = "furniture/sitting_13.jpg", FurnitureId=1 },
                new Image { Name = "furniture/sitting_14.jpg", FurnitureId=1 },
                new Image { Name = "furniture/vienza_11.jpg", FurnitureId=2 },
                new Image { Name = "furniture/vienza_12.jpg", FurnitureId=2 },
                new Image { Name = "furniture/vienza_13.jpg", FurnitureId=2 },
                new Image { Name = "furniture/mavenna_12.jpg", FurnitureId=3 },
                new Image { Name = "furniture/mavenna_13.jpg", FurnitureId=3 },
                new Image { Name = "furniture/mavenna_14.jpg", FurnitureId=3 },
                new Image { Name = "furniture/mavenna_15.jpg", FurnitureId=3 },
                new Image { Name = "furniture/angel_1.jpg", FurnitureId=4 },
                new Image { Name = "furniture/angel_2.jpg", FurnitureId=4 },
                new Image { Name = "furniture/angel_3.jpg", FurnitureId=4 },
                new Image { Name = "furniture/angel_4.jpg", FurnitureId=4 },
                new Image { Name = "furniture/angel_5.jpg", FurnitureId=4 },
                new Image { Name = "furniture/joyful_2.jpg", FurnitureId=5 },
                new Image { Name = "furniture/joyful_3.jpg", FurnitureId=5 },
                new Image { Name = "furniture/portivo_1.jpg", FurnitureId=6 },
                new Image { Name = "furniture/portivo_2.jpg", FurnitureId = 6 },
                new Image { Name = "furniture/portivo_3.jpg", FurnitureId = 6 }

            );

            context.AboutFeatured.AddOrUpdate(a => new { a.Title, a.Content },
            new AboutFeatured { Title= "Featured Products", Content= "Who are in extremely love with eco friendly system." }

            );

            context.CategoryHeader.AddOrUpdate(c => c.Title,
            new CategoryPageHeader { Title= "Shop Category Page", Image= "furniture/backg.jpg" }

            );

            context.About.AddOrUpdate(a => new { a.Title, a.Content },
            new About { Title = "About Us", Content = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore dolore magna aliqua." }

           );

            context.LoginHeader.AddOrUpdate(l => l.Title,
            new LoginHeader { Title="Login/Register", Image="furniture/backg.jpg"}

            );

            context.Roles.AddOrUpdate(
            new ApplicationRole { Name="Admin"},
            new ApplicationRole { Name="User"}
            );

                      //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
