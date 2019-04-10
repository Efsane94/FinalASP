using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_Final.Models;
using ASP_Final.DAL;
using System.Threading.Tasks;
using ASP_Final.Extensions;
using static ASP_Final.Utilities.Utilities;

namespace ASP_Final.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryHeaderController : Controller
    {
        private readonly FurnitureContext db;

        public CategoryHeaderController()
        {
            db = new FurnitureContext();
        }
        // GET: Admin/CategoryHeader
        public ActionResult Index()
        {
            return View(db.CategoryHeader.First());
        }

        public ActionResult Edit()
        {
            return View(db.CategoryHeader.First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Title,Photo")] CategoryPageHeader header)
        {
            if (!ModelState.IsValid) return View(header);

            CategoryPageHeader headerDb = db.CategoryHeader.First();
            if (header.Photo != null)
            {
                if (!header.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Photo is not valid");
                    return View(header);
                }
                RemoveImage(headerDb.Image, "~/Assets/img");
                headerDb.Image = header.Photo.SaveImage("furniture", "~/Assets/img");
            }

            headerDb.Title = header.Title;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}