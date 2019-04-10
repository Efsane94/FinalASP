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
    public class CategoryController : Controller
    {
        private readonly FurnitureContext db;

        public CategoryController()
        {
            db = new FurnitureContext();
        }
        // GET: Admin/Category
        public ActionResult Index()
        {
            return View(db.Category);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include ="Name")] Category category)
        {
            if (!ModelState.IsValid) return View(category);

            db.Category.Add(category);
             await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? Id)
        {
            if (Id == null) return HttpNotFound("Id is not found");

            var category = db.Category.Find(Id);

            if (category == null) return HttpNotFound("Category is not found");

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteCategory(int? Id)
        {
            if (Id == null) return HttpNotFound("Id is not found");

            var categoryDb = db.Category.Find(Id);

            if (categoryDb == null) return HttpNotFound("Customer is not found");

            db.Category.Remove(categoryDb);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? Id)
        {
            if (Id == null) return HttpNotFound("Id is not found");

            var category = db.Category.Find(Id);

            if (category == null) return HttpNotFound("Category is not found");

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include ="Id,Name")] Category category)
        {
            if (!ModelState.IsValid) return View(category);

            Category categoryDb = db.Category.Find(category.Id);

            categoryDb.Name = category.Name;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}