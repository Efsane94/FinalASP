using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_Final.Models;
using ASP_Final.DAL;
using ASP_Final.Models.ViewModel;

namespace ASP_Final.Controllers
{
    public class HomeController : Controller
    {
        private readonly FurnitureContext _context;
        public HomeController()
        {
            _context = new FurnitureContext();
        }
        public ActionResult Index()
        {
            FurnitureImage_VM vm = new FurnitureImage_VM
            {
                Header=_context.Header.First(),
                Categories=_context.Category,
                Furnitures=_context.Furniture,
                Images=_context.Image,
                AboutFeatured=_context.AboutFeatured.First()
                
            };
            
            return View(vm);
        }

       public ActionResult Details(int? id)
        {
            Details_VM vm = new Details_VM
            {
                Furniture = _context.Furniture.Where(f => f.Id == id).FirstOrDefault(),
                CategoryId = _context.Furniture.Where(f => f.Id == id).FirstOrDefault().CategoryId
            };
             
            return View(vm);
        }

    }
}