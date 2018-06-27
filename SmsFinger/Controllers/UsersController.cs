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
            user userObj = new user();
            using (smsfingerDB dbModel = new smsfingerDB())
            {
                userObj = dbModel.users.Where(x => x.id == id).FirstOrDefault();
                var orderView = (from u in dbModel.users join r in dbModel.userroles on u.rid equals r.rid where u.id==id select new {u.firstname,u.lastname,u.status,u.email,u.acid,u.gender,r.rolename });

                return View(orderView);
            }
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            List<accout> objAcCol = new List<accout>();

            using (smsfingerDB ObjDB = new smsfingerDB())
            {
                objAcCol = ObjDB.accouts.ToList<accout>();
            }

            List<SelectListItem> items = new List<SelectListItem>();

            items.Add(new SelectListItem { Text = "---Select Account---", Value = "" });
            foreach (accout ac in objAcCol)
            {
                items.Add(new SelectListItem { Text = ac.id + "-" + ac.acname, Value = "" + ac.id });
            }
            ViewData["ListItems"] = items;

            return View(new user());
        }

        // POST: Users/Create
        [HttpPost]
        public ActionResult Create(user usermodel, FormCollection form)
        {
            try
            {
                // TODO: Add insert logic here
                using (smsfingerDB objDb = new smsfingerDB())
                {
                    usermodel.acid = Convert.ToInt32("" + form["SelectedItem"]);
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
                ViewBag.Message = "" + ex.Message;
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
            userObj.remarks = "";
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem
            {
                Text = "Active",
                Value = "1",
                Selected = userObj.status == 1 ? true : false
            });
            items.Add(new SelectListItem
            {
                Text = "InActive",
                Value = "2",
                Selected = userObj.status == 2 ? true : false
            });

            ViewData["ListItems"] = items;

            return View(userObj);
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(user userModel, FormCollection form)
        {
            try
            {
                // TODO: Add update logic here
                using (smsfingerDB dbModel = new smsfingerDB())
                {
                    var UserData = dbModel.users.Where(x => x.id == userModel.id).FirstOrDefault();
                    if (UserData != null)
                    {
                        UserData.firstname = userModel.firstname;
                        UserData.lastname = userModel.lastname;
                        UserData.gender = userModel.gender;
                        UserData.email = userModel.email;
                        UserData.acid = userModel.acid;
                        UserData.remarks = userModel.remarks;
                        UserData.status = Convert.ToInt32("" + form["SelectedItem"]);
                        dbModel.Entry(UserData).State = System.Data.EntityState.Modified;
                        dbModel.SaveChanges();
                    }
                    else
                    {
                        ViewBag.Message = "Invalid Attempt";
                        return View();
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Message = "" + ex.Message;
                return View();
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            user userObj = new user();
            using (smsfingerDB dbModel = new smsfingerDB())
            {
                userObj = dbModel.users.Where(x => x.id == id).FirstOrDefault();
            }
            userObj.remarks = "";
            return View(userObj);
        }

        // POST: Users/Delete/5
        [HttpPost]
        public ActionResult Delete(user userModel)
        {
            try
            {
                // TODO: Add delete logic here
                using (smsfingerDB dbModel = new smsfingerDB())
                {
                    var userData = dbModel.users.Where(x => x.id == userModel.id).FirstOrDefault();
                    if (userData != null)
                    {
                        userData.remarks = "" + userModel.remarks;
                        userData.status = -1;
                        dbModel.Entry(userData).State = System.Data.EntityState.Modified;
                        dbModel.SaveChanges();
                    }
                    else
                    {
                        ViewBag.Message = "Invalid Attempt";
                        return View();
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Message = "" + ex.Message;
                return View();
            }
        }
    }
}
