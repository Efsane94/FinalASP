using ASP_Final.Identity;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_Final.Models;
using ASP_Final.DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System.Security.Claims;

namespace ASP_Final.Controllers
{
    public class AccountController : Controller
    {
        private readonly FurnitureContext _context;
        private UserManager<ApplicationUser> userManager;
        private RoleManager<ApplicationRole> roleManager;

        public AccountController()
        {
            FurnitureContext db = new FurnitureContext();
            UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(db);

            userManager = new UserManager<ApplicationUser>(userStore);

            RoleStore<ApplicationRole> roleStore = new RoleStore<ApplicationRole>(db);
            roleManager = new RoleManager<ApplicationRole>(roleStore);
        }

        // GET: Account
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Register()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();

                user.Name = model.Name;
                user.Surname = model.Surname;
                user.Email = model.Email;
                user.UserName = model.UserName;

                IdentityResult iResult = userManager.Create(user, model.Password);

                if (iResult.Succeeded)
                {
                    // User isminde bir Role ataması yapacağız. Bu rolü ilerleyen kısımda oluşturacağız
                    
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("RegisterUser", "Error");
                }
            }

            return View(model);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = userManager.Find(model.UserName, model.Password);

                if (user != null)
                {
                    
                    IAuthenticationManager authManager = HttpContext.GetOwinContext().Authentication;

                    ClaimsIdentity identity = userManager.CreateIdentity(user, "ApplicationCookie");
                    AuthenticationProperties authProps = new AuthenticationProperties();
                    authManager.SignIn(authProps, identity);
                    if (userManager.IsInRole(user.Id, "Admin"))
                    {
                        return RedirectToAction("Index", "Admin/Dashboard");
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("LoginUser", "User not found");
                }
            }
            return View(model);
        }

        [Authorize]
        public ActionResult Logout()
        {
            IAuthenticationManager authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}