using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_Final.Models;
using ASP_Final.Models.ViewModel;
using ASP_Final.DAL;
using System.Threading.Tasks;

namespace ASP_Final.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FurnitureController : Controller
    {
        private readonly FurnitureContext db;

        public FurnitureController()
        {
            
            db = new FurnitureContext();
        }
        // GET: Admin/Furniture
        public ActionResult Index()
        {
            
            return View(db.Furniture.ToList());
        }

        public ActionResult Create()
        {
            CF_VM cf = new CF_VM
            {
                Categories = new SelectList(db.Category.ToList(), "Id", "Name"),
                Furniture = new Furniture()
            };
            return View(cf);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include ="Name,Price,CategoryId")] Furniture furniture)
        {
            if (!ModelState.IsValid) return View(furniture);

            db.Furniture.Add(furniture);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? Id)
        {
            if (Id == null) return HttpNotFound("Id is not found");

            Furniture furniture = db.Furniture.Find(Id);

            if (furniture == null) return HttpNotFound("Furniture is not found");

            return View(furniture);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<ActionResult> DeleteFurniture(int? Id)
        {
            if (Id == null) return HttpNotFound("Id is not found");

            Furniture furniture = db.Furniture.Find(Id);

            if (furniture == null) return HttpNotFound("Furniture is not found");

            db.Furniture.Remove(furniture);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? Id)
        {
            if (Id == null) return HttpNotFound("Id is not found");

            Furniture furniture = db.Furniture.Find(Id);

            if (furniture == null) return HttpNotFound("Furniture is not found"); 

            CF_VM f = new CF_VM
            {
                Categories = new SelectList(db.Category.ToList(), "Id", "Name"),
                Furniture = furniture
            };

            return View(f);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include ="Id,Name,Price,CategoryId")] Furniture furniture)
        {
            if (!ModelState.IsValid) return View(furniture);

            Furniture furnitureDb = db.Furniture.Find(furniture.Id);

            furnitureDb.Name = furniture.Name;
            furnitureDb.Price = furniture.Price;
            furnitureDb.CategoryId = furniture.CategoryId;

            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}