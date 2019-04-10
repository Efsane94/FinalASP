using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_Final.Models;
using ASP_Final.Models.ViewModel;
using ASP_Final.DAL;
using System.Threading.Tasks;
using ASP_Final.Extensions;
using static ASP_Final.Utilities.Utilities;

namespace ASP_Final.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ImagesController : Controller
    {
        // GET: Admin/Images
        private readonly FurnitureContext db;

        public ImagesController()
        {
            db = new FurnitureContext();
        }
        public ActionResult Index()
        {
            return View(db.Image.ToList());
        }

        public ActionResult Create()
        {
            F_Images_Vm vm = new F_Images_Vm
            {
                Furnitures = new SelectList(db.Furniture.ToList(), "Id", "Name"),
                Image = new Image()
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "FurnitureId,Photo")] Image image)
        {
            if (!ModelState.IsValid) return View(image);
            if (image.Photo != null)
            {
                if (!image.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Photo Type is not valid");
                    return View(image);
                }
            }

            image.Name=image.Photo.SaveImage("furniture", "~/Assets/img");

            db.Image.Add(image);
            await db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? Id)
        {
            if (Id == null) return HttpNotFound("Id is not found");

            var image = db.Image.Find(Id);

            if(image==null) return HttpNotFound("Image is not found");

            return View(image);
        }

        [ActionName("Delete")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteImage(int? Id)
        {
            if (Id == null) return HttpNotFound("Id is not found");

            var imageDb = db.Image.Find(Id);

            if (imageDb == null) return HttpNotFound("Image is not found");

            RemoveImage(imageDb.Name, "~/Assets/img");

            db.Image.Remove(imageDb);
            await db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? Id)
        {
            if (Id == null) return HttpNotFound("Id is not found");

            var imageDb = db.Image.Find(Id);

            if (imageDb == null) return HttpNotFound("Image is not found");

            F_Images_Vm vm = new F_Images_Vm
            {
                Furnitures = new SelectList(db.Furniture.ToList(), "Id", "Name"),
                Image = imageDb
            };
            return View(vm);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include ="Id,Photo,FurnitureId")] Image image)
        {
            if (!ModelState.IsValid) return View(image);

            Image imageDb = db.Image.Find(image.Id);

            if (image.Photo != null)
            {
                if (!image.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Photo is not valid");
                    return View(image);
                }
                RemoveImage(imageDb.Name, "~/Assets/img");
                imageDb.Name = image.Photo.SaveImage("furniture", "~/Assets/img");
            }

            imageDb.FurnitureId = image.FurnitureId;

            await db.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}