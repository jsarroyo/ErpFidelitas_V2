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
    public class MovementAccountReceivableController : Controller
    {
        MovementAccountReceivable movAccRec;
        List<MovementAccountReceivable> movAccReceivables;
        Response responseClient;
        // GET: MovementAccountReceivable
        public async Task<ActionResult> Index()
        {
            movAccReceivables = new List<MovementAccountReceivable>();
            responseClient = new Response();
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://localhost:44331/General/MovementsAccountsReceivable/ObtenerTodas");
                if(response.IsSuccessStatusCode)
                {
                    var str = await response.Content.ReadAsStringAsync();
                    responseClient = JsonConvert.DeserializeObject<Response>(str);
                }
                if(responseClient.Success)
                {
                    movAccReceivables = JsonConvert.DeserializeObject<List<MovementAccountReceivable>>(responseClient.Value.ToString());
                }
            }
            return View(movAccReceivables);
        }

        // GET: MovementAccountReceivable/Details/5
        public async Task<ActionResult> Details(int id)
        {
            movAccRec = new MovementAccountReceivable();
            responseClient = new Response();
            using(var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"https://localhost:44331/General/MovementsAccountsReceivable/ObtenerUno?id={id}");
                if (response.IsSuccessStatusCode)
                {
                    var str = await response.Content.ReadAsStringAsync();
                    responseClient = JsonConvert.DeserializeObject<Response>(str);
                }
                if (responseClient.Success)
                {
                    movAccRec = JsonConvert.DeserializeObject<MovementAccountReceivable>(responseClient.Value.ToString());
                }
            }
            return View(movAccRec);
        }

        // GET: MovementAccountReceivable/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MovementAccountReceivable/Create
        [HttpPost]
        public async Task<ActionResult> Create(FormCollection collection)
        {
            try
            {
                responseClient = new Response();

                using (var client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(collection);
                    var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync($"https://localhost:44331/General/MovementsAccountsReceivable/CrearUno", stringContent);

                    string resultContent = response.Content.ReadAsStringAsync().Result;

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MovementAccountReceivable/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MovementAccountReceivable/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, FormCollection collection)
        {
            try
            {
                responseClient = new Response();

                using (var client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(collection);
                    var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PutAsync($"https://localhost:44331/General/MovementsAccountsReceivable/ActualizarUno", stringContent);

                    string resultContent = response.Content.ReadAsStringAsync().Result;

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MovementAccountReceivable/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MovementAccountReceivable/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, FormCollection collection)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(collection);
                    var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.DeleteAsync($"https://localhost:44331/General/MovementsAccountsReceivable/BorrarUno?id={id}");

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
