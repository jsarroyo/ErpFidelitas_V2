using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Views.ErpFidelitas.General.v2.Controllers
{
    public class ParameterController : Controller
    {
        // GET: Parameter
        public ActionResult Index()
        {
            return View();
        }

        // GET: Parameter/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Parameter/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Parameter/Create
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

        // GET: Parameter/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Parameter/Edit/5
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

        // GET: Parameter/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Parameter/Delete/5
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
