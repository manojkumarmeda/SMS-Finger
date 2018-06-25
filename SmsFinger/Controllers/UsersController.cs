using SmsFinger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmsFinger.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            List<user> objUserCol = new List<user>();

            using (smsfingerDB ObjDB = new smsfingerDB())
            {
                objUserCol = ObjDB.users.ToList<user>();
            }
            return View(objUserCol);
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View(new user());
        }

        // POST: Users/Create
        [HttpPost]
        public ActionResult Create(user usermodel)
        {
            try
            {
                // TODO: Add insert logic here
                using (smsfingerDB objDb = new smsfingerDB())
                {
                    usermodel.datecreated = DateTime.Now;
                    usermodel.status = 1;
                    usermodel.usercreated = 1;
                    objDb.users.Add(usermodel);
                    objDb.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            user userObj = new user();
            using (smsfingerDB dbModel = new smsfingerDB())
            {
                userObj = dbModel.users.Where(x => x.id == id).FirstOrDefault();
            }
            return View(userObj);
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(user userModel)
        {
            try
            {
                // TODO: Add update logic here
                using (smsfingerDB dbModel = new smsfingerDB())
                {
                    dbModel.Entry(User).State = System.Data.EntityState.Modified;
                    dbModel.SaveChanges();
                }
                    return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Users/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
