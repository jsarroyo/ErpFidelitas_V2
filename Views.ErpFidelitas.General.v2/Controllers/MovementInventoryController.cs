using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Views.ErpFidelitas.General.v2.Controllers
{
    public class MovementInventoryController : Controller
    {
        // GET: MovementInventory
        public ActionResult Index()
        {
            return View();
        }

        // GET: MovementInventory/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MovementInventory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MovementInventory/Create
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

        // GET: MovementInventory/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MovementInventory/Edit/5
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

        // GET: MovementInventory/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MovementInventory/Delete/5
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
