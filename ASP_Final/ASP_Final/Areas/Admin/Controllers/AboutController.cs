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
    public class AboutController : Controller
    {
        private readonly FurnitureContext db;

        public AboutController()
        {
            db = new FurnitureContext();
        }
        // GET: Admin/About
        public ActionResult Index()
        {
            return View(db.About.First());
        }

        public ActionResult Edit()
        { 
            return View(db.About.First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Title,Content")]About about)
        {
            if (!ModelState.IsValid) return View(about);
            About aboutDb = db.About.First();

            aboutDb.Title = about.Title;
            aboutDb.Content = about.Content;

            await db.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}