using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;


namespace Vidly.Controllers
{
    public class RoleController : Controller
    {
        // GET: Role
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)

                if (User.IsInRole("Admin"))
                {
                    var context = new ApplicationDbContext();
                    var roles = context.Roles.ToList();

                    return View(roles);
                }


            return RedirectToAction("Index", "Home");

        }

        public ActionResult Create()
        {

            return View();
        }

    }
}