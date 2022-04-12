using Asp.ErpFidelitas.General.v2.Entities;
using Asp.ErpFidelitas.General.v2.Utilities;
using Newtonsoft.Json; 
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Asp.ErpFidelitas.General.v2.Controllers
{
    public class MovementDebtToPayController : Controller
    {
        MovementDebtToPay debtToPay;
        List<MovementDebtToPay> movements;
        Response responseClient;
        // GET: MovementDebtToPay
        public async Task<ActionResult> Index()
        {
            movements = new List<MovementDebtToPay>();
            responseClient = new Response();
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://localhost:44331/General/MovementsDebtsToPay/ObtenerTodas");
                if (response.IsSuccessStatusCode)
                {
                    var str = await response.Content.ReadAsStringAsync();
                    responseClient = JsonConvert.DeserializeObject<Response>(str);
                }
                if (responseClient.Success)
                {
                    movements = JsonConvert.DeserializeObject<List<MovementDebtToPay>>(responseClient.Value.ToString());
                }
            }
            return View(movements);
        }

        // GET: MovementDebtToPay/Details/5
        public async Task<ActionResult> Details(int id)
        {
            debtToPay = new MovementDebtToPay();
            responseClient = new Response();

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"https://localhost:44331/General/MovementsDebtsToPay/ObtenerUno?id={id}");
                if (response.IsSuccessStatusCode)
                {
                    var str = await response.Content.ReadAsStringAsync();
                    responseClient = JsonConvert.DeserializeObject<Response>(str);
                }
                if (responseClient.Success)
                {
                    debtToPay = JsonConvert.DeserializeObject<MovementDebtToPay>(responseClient.Value.ToString());
                }
            }
            return View(debtToPay);
        }

        // GET: MovementDebtToPay/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MovementDebtToPay/Create
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

                    HttpResponseMessage response = await client.PostAsync($"https://localhost:44331/General/MovementsDebtsToPay/CrearUno", stringContent);

                    string resultContent = response.Content.ReadAsStringAsync().Result;

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MovementDebtToPay/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MovementDebtToPay/Edit/5
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

                    HttpResponseMessage response = await client.PutAsync($"https://localhost:44331/General/MovementsDebtsToPay/ActualizarUno", stringContent);

                    string resultContent = response.Content.ReadAsStringAsync().Result;

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MovementDebtToPay/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MovementDebtToPay/Delete/5
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

                    HttpResponseMessage response = await client.DeleteAsync($"https://localhost:44331/General/MovementsDebtsToPay/BorrarUno?id={id}");

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
