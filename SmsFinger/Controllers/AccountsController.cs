using SmsFinger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmsFinger.Controllers
{
    public class AccountsController : Controller
    {
        // GET: Accounts
        public ActionResult Index()
        {
            List<accout> objAccountsCol = new List<accout>();

            using (smsfingerDB ObjDB = new smsfingerDB())
            {
                objAccountsCol = ObjDB.accouts.ToList<accout>();
            }
            return View(objAccountsCol);
        }

        // GET: Accounts/Details/5
        public ActionResult Details(int id)
        {
            accout accountObj = new accout();
            using (smsfingerDB dbModel = new smsfingerDB())
            {
                accountObj = dbModel.accouts.Where(x => x.id == id).FirstOrDefault();
            }
            accountObj.remarks = "";

            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem
            {
                Text = "Active",
                Value = "1",
                Selected = accountObj.status == 1 ? true : false
            });
            items.Add(new SelectListItem
            {
                Text = "InActive",
                Value = "2",
                Selected = accountObj.status == 2 ? true : false
            });

            ViewData["ListItems"] = items;

            return View(accountObj);
        }

        // GET: Accounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Accounts/Create
        [HttpPost]
        public ActionResult Create(accout accollection)
        {
            try
            {
                // TODO: Add insert logic here
                using (smsfingerDB smsDB = new smsfingerDB())
                {
                    accollection.datecreated = DateTime.Now;
                    accollection.status = 1;
                    smsDB.accouts.Add(accollection);
                    smsDB.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Message = "" + ex.Message;
                return View();
            }
        }

        // GET: Accounts/Edit/5
        public ActionResult Edit(int id)
        {
            accout accountObj = new accout();
            using (smsfingerDB dbModel = new smsfingerDB())
            {
                accountObj = dbModel.accouts.Where(x => x.id == id).FirstOrDefault();
            }
            accountObj.remarks = "";

            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem
            {
                Text = "Active",
                Value = "1",
                Selected = accountObj.status == 1 ? true : false
            });
            items.Add(new SelectListItem
            {
                Text = "InActive",
                Value = "2",
                Selected = accountObj.status == 2 ? true : false
            });

            ViewData["ListItems"] = items;

            return View(accountObj);
        }

        // POST: Accounts/Edit/5
        [HttpPost]
        public ActionResult Edit(accout accModel, FormCollection form)
        {
            try
            {
                // TODO: Add update logic here

                using (smsfingerDB dbModel = new smsfingerDB())
                {
                    var accountData = dbModel.accouts.Where(x => x.id == accModel.id).FirstOrDefault();
                    if (accountData != null)
                    {
                        accountData.acname = accModel.acname;
                        accountData.mpoc = accModel.mpoc;
                        accountData.mobileno = accModel.mobileno;
                        accountData.email = accModel.email;
                        accountData.remarks = accModel.remarks;
                        accountData.status = Convert.ToInt32("" + form["SelectedItem"]);
                        dbModel.Entry(accountData).State = System.Data.EntityState.Modified;
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

        // GET: Accounts/Delete/5
        public ActionResult Delete(int id)
        {
            accout accountObj = new accout();
            using (smsfingerDB dbModel = new smsfingerDB())
            {
                accountObj = dbModel.accouts.Where(x => x.id == id).FirstOrDefault();
            }
            accountObj.remarks = "";

            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem
            {
                Text = "Active",
                Value = "1",
                Selected = accountObj.status == 1 ? true : false
            });
            items.Add(new SelectListItem
            {
                Text = "InActive",
                Value = "2",
                Selected = accountObj.status == 2 ? true : false
            });

            ViewData["ListItems"] = items;
            return View(accountObj);
        }

        // POST: Accounts/Delete/5
        [HttpPost]
        public ActionResult Delete(accout accoutCol, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                using (smsfingerDB dbModel = new smsfingerDB())
                {
                    var accountData = dbModel.accouts.Where(x => x.id == accoutCol.id).FirstOrDefault();
                    if (accountData != null)
                    {
                        accountData.remarks=""+ accoutCol.remarks;
                        accountData.status = -1;
                        dbModel.Entry(accountData).State = System.Data.EntityState.Modified;
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
            catch(Exception ex)
            {
                ViewBag.Message = ""+ ex.Message;
                return View();
            }
        }
    }
}
