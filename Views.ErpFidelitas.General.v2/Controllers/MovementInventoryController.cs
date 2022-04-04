using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Views.ErpFidelitas.General.v2.Entities;
using Views.ErpFidelitas.General.v2.Utilities;

namespace Views.ErpFidelitas.General.v2.Controllers
{
    public class MovementInventoryController : Controller
    {
        MovementInventory movementInventory;
        List<MovementInventory> movements;
        Response responseClient;
        // GET: MovementInventory
        public async Task<ActionResult> Index()
        {
            movements = new List<MovementInventory>();
            responseClient = new Response();

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://localhost:44331/General/MovementsInventory/ObtenerTodas");
                if (response.IsSuccessStatusCode)
                {
                    var str = await response.Content.ReadAsStringAsync();
                    responseClient = JsonConvert.DeserializeObject<Response>(str);
                }
                if (responseClient.Success)
                {
                    movements = JsonConvert.DeserializeObject<List<MovementInventory>>(responseClient.Value.ToString());
                }
            }
            return View(movements);
        }

        // GET: MovementInventory/Details/5
        public async Task<ActionResult> Details(int id)
        {
            movementInventory = new MovementInventory();
            responseClient = new Response();

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"https://localhost:44331/General/MovementsInventory/ObtenerUno?id={id}");
                if (response.IsSuccessStatusCode)
                {
                    var str = await response.Content.ReadAsStringAsync();
                    responseClient = JsonConvert.DeserializeObject<Response>(str);
                }
                if (responseClient.Success)
                {
                    movementInventory = JsonConvert.DeserializeObject<MovementInventory>(responseClient.Value.ToString());
                }
            }
            return View(movementInventory);
        }

        // GET: MovementInventory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MovementInventory/Create
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

                    HttpResponseMessage response = await client.PostAsync($"https://localhost:44331/General/MovementsInventory/CrearUno", stringContent);

                    string resultContent = response.Content.ReadAsStringAsync().Result;

                }

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
        public async Task<ActionResult> Edit(int id, FormCollection collection)
        {
            try
            {
                responseClient = new Response();

                using (var client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(collection);
                    var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PutAsync($"https://localhost:44331/General/MovementsInventory/ActualizarUno", stringContent);

                    string resultContent = response.Content.ReadAsStringAsync().Result;

                }

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
        public async Task<ActionResult> Delete(int id, FormCollection collection)
        {
            try
            {
                responseClient = new Response();

                using (var client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(collection);
                    var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.DeleteAsync($"https://localhost:44331/General/MovementsInventory/BorrarUno?id={id}");

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
