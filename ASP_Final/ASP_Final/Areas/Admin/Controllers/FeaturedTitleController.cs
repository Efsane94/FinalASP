using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_Final.Models;
using ASP_Final.DAL;
using System.Threading.Tasks;

namespace ASP_Final.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FeaturedTitleController : Controller
    {
        private readonly FurnitureContext db;

        public FeaturedTitleController()
        {
            db = new FurnitureContext();
        }
        // GET: Admin/FeaturedTitle
        public ActionResult Index()
        {
            return View(db.AboutFeatured.First());
        }

        public ActionResult Edit()
        {
            return View(db.AboutFeatured.First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<ActionResult> Edit([Bind(Include="Id,Title,Content")] AboutFeatured featured)
        {
            if (!ModelState.IsValid) return View(featured);

            var featuredDb = db.AboutFeatured.First();

            featuredDb.Title = featured.Title;
            featuredDb.Content = featured.Content;

             await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}