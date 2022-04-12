using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApp.ErpFidelitas.General.v2.Entities;
using WebApp.ErpFidelitas.General.v2.Utilities;

namespace WebApp.ErpFidelitas.General.v2.Controllers
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
                HttpResponseMessage response = await client.GetAsync("https://localhost:44331/General/DocumentTypes/ObtenerTodas");
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
        public async Task< ActionResult> Details(int id)
        {
            documentTip = new DocumentType();
            responseClient = new Response();

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"https://localhost:44331/General/DocumentTypes/ObtenerUno?id={id}");
                if (response.IsSuccessStatusCode)
                {
                    var str = await response.Content.ReadAsStringAsync();
                    responseClient = JsonConvert.DeserializeObject<Response>(str);
                }
                if (responseClient.Success)
                {
                    documentTip = JsonConvert.DeserializeObject<DocumentType>(responseClient.Value.ToString());
                }
            }
            return View(documentTip);
        }

        // GET: DocumentType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DocumentType/Create
        [HttpPost]
        public async Task< ActionResult> Create(FormCollection collection)
        {
            try
            {
                documentTip = new DocumentType();
                responseClient = new Response();

                using (var client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(collection);
                    var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync($"https://localhost:44331/General/DocumentTypes/CrearUno", stringContent);

                    string resultContent = response.Content.ReadAsStringAsync().Result;

                }

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
        public async Task< ActionResult> Edit(int id, FormCollection collection)
        {
            try
            {
                documentTip = new DocumentType();
                responseClient = new Response();

                using (var client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(collection);
                    var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PutAsync($"https://localhost:44331/General/DocumentTypes/ActualizarUno", stringContent);

                    string resultContent = response.Content.ReadAsStringAsync().Result;

                }
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
        public  async Task< ActionResult> Delete(int id, FormCollection collection)
        {
            try
            {
                responseClient = new Response();

                using (var client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(collection);
                    var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.DeleteAsync($"https://localhost:44331/General/DocumentTypes/BorrarUno?id={id}");

                    string resultContent = response.Content.ReadAsStringAsync().Result;

                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
