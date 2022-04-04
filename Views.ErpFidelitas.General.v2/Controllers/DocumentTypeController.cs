using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Views.ErpFidelitas.General.v2.Entities;
using Views.ErpFidelitas.General.v2.Utilities;

namespace Views.ErpFidelitas.General.v2.Controllers
{
    public class DocumentTypeController : Controller
    {
        DocumentType documentTip;
        List<DocumentType> document;
        Response responseClient;
        // GET: DocumentType
        public  async Task<ActionResult> Index()
        {
            document = new List<DocumentType>();
            responseClient = new Response();

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://localhost:44313/General/DocumentType/ObtenerTodas");
                if (response.IsSuccessStatusCode)
                {
                    var str = await response.Content.ReadAsStringAsync();
                    responseClient = JsonConvert.DeserializeObject<Response>(str);
                }
                if (responseClient.Success)
                {
                    document = JsonConvert.DeserializeObject<List<DocumentType>>(responseClient.Value.ToString());
                }
            }
            return View(document);
        }

        // GET: DocumentType/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DocumentType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DocumentType/Create
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

        // GET: DocumentType/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DocumentType/Edit/5
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

        // GET: DocumentType/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DocumentType/Delete/5
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
