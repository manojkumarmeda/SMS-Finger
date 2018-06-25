using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmsFinger.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Home()
        {
            //User usrcol = new User();
            //usrcol.Save();
            return View();
        }
    }
}