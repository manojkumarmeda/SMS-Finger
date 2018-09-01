using Newtonsoft.Json;
using SmsFinger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SmsFinger.Controllers
{
    public class ContactsController : Controller
    {
        // GET: Contacts
        public ActionResult Index()
        {
            List<contact> objAccountsCol = new List<contact>();

            using (smsfingerDB ObjDB = new smsfingerDB())
            {
                objAccountsCol = ObjDB.contacts.ToList<contact>();
            }
            return View(objAccountsCol);
        }

        // GET: Contacts/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Contacts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contacts/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                string contactname = collection["contactname"];
                string mobilenumber = collection["mobileno"];
                string email = collection["email"];

                // TODO: Add insert logic here
                using (smsfingerDB smsDB = new smsfingerDB())
                {
                    contact cdet = new contact();
                    cdet.contactname = "" + contactname;
                    cdet.mobileno = ""+mobilenumber;
                    cdet.contactname = "" + contactname;
                    cdet.status = 1;
                    cdet.datecreated = DateTime.Now;

                    smsDB.contacts.Add(cdet);
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

        // GET: Contacts/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Contacts/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contacts/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Contacts/Delete/5
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
