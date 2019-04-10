using ASP_Final.DAL;
using ASP_Final.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_Final.Controllers
{
    public class ShopCategoryController : Controller
    {
        private readonly FurnitureContext _context;

        public ShopCategoryController()
        {
            _context = new FurnitureContext();
        }
        // GET: Category
        public ActionResult Index(int? id)
        {
            FurnitureCategory_VM vm = new FurnitureCategory_VM()
            {
                Furnitures = _context.Furniture,
                CategoryPage=_context.CategoryHeader.First()
            };
            if (id == null)
            {
                ViewBag.categoryName = _context.Category.ToList();
                return View(vm);

            }

            return View();
        }
    }
}