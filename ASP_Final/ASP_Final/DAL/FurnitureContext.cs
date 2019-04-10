using ASP_Final.Identity;
using ASP_Final.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASP_Final.DAL
{
    public class FurnitureContext: IdentityDbContext<ApplicationUser>
    {
        public FurnitureContext() : base("FurnitureContext")
        {
            
        }

        public DbSet<Header> Header { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Furniture> Furniture { get; set; }
        public DbSet<Image> Image { get; set; }
        public DbSet<AboutFeatured> AboutFeatured { get; set; }
        public DbSet<About> About { get; set; }
        public DbSet<CategoryPageHeader> CategoryHeader { get; set; }
        public DbSet<LoginHeader> LoginHeader { get; set; }

    }
}