using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_Final.Models;
using ASP_Final.DAL;
using ASP_Final.Extensions;
using static ASP_Final.Utilities.Utilities;

using System.Threading.Tasks;

namespace ASP_Final.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HeaderController : Controller
    {

        // GET: Admin/Header
        private readonly FurnitureContext db;

        public HeaderController()
        {
            db = new FurnitureContext();
        }

        public ActionResult Index()
        {
            return View(db.Header.First());
        }

        public ActionResult Edit()
        {
            return View(db.Header.First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Title,Content,Photo")]Header header)
        {
            if (!ModelState.IsValid) return View(header);

            Header headerDb = db.Header.First();
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
            headerDb.Content = header.Content;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}