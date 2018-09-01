using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SmsFinger.Models;

namespace SmsFinger.Controllers
{
    public class SecurityController : Controller
    {
        // GET: Security
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            try
            {
                // Lets first check if the Model is valid or not
                if (ModelState.IsValid)
                {
                    user objUser = new user();
                    using (smsfingerDB smsDB = new smsfingerDB())
                    {
                        objUser = smsDB.users.Where(x => x.email == username && x.password == password).FirstOrDefault();
                    }

                    if (objUser != null)
                    {
                        if (objUser.status == 1)
                        {
                            Session["UserName"] = objUser.firstname + " " + objUser.lastname;
                            Session["UserEmail"] = objUser.email;
                            Session["Uid"] = objUser.id;
                            Session["Acid"] = objUser.acid;
<<<<<<< HEAD

=======
>>>>>>> 736521f8d422f73f9913bb1a910408f79d162f2b
                            FormsAuthentication.SetAuthCookie("" + Request.Form["authkey"], false);
                            return RedirectToAction("Index", "Users");
                        }
                        else
                        {
                            return View();
                        }
                    }
                    else
                    {
                        ViewBag.Message = "Invalid User Credentials";
                        return View();
                    }
                }
                else
                {
                    return View();
                }

            }
            catch (Exception ex)
            {
                ViewBag.Message = "" + ex.Message;
                return View();
            }

        }

        [HttpGet]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            TempData["User"] = null;
            Session.Abandon();
            return RedirectToAction("Login", "Security");
        }
    }
}