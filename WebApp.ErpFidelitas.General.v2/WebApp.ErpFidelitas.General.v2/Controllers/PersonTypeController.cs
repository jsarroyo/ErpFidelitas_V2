using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.ErpFidelitas.General.v2.Controllers
{
    public class PersonTypeController : Controller
    {
        // GET: PersonType
        public ActionResult Index()
        {
            return View();
        }

        // GET: PersonType/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PersonType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonType/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonType/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PersonType/Edit/5
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

        // GET: PersonType/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PersonType/Delete/5
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
