using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_Final.Models;
using ASP_Final.DAL;

namespace ASP_Final.Controllers
{
    public class AjaxController : Controller
    {
        private readonly FurnitureContext db;

        public AjaxController()
        {
            db = new FurnitureContext();
        }
        // GET: Ajax
        public ActionResult Index()
        {
            return View();
        }
    }
}