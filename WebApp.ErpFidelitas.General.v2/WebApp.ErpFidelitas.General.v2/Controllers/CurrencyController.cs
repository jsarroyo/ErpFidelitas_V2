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
    public class CurrencyController : Controller
    {
        Currency currency;
        List<Currency> currenc;
        Response responseClient;
        // GET: Currency
        public async Task<ActionResult >Index()
        {
            currenc = new List<Currency>();
            responseClient = new Response();

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://localhost:44331/General/Currencys/ObtenerTodas");
                if (response.IsSuccessStatusCode)
                {
                    var str = await response.Content.ReadAsStringAsync();
                    responseClient = JsonConvert.DeserializeObject<Response>(str);
                }
                if (responseClient.Success)
                {
                    currenc = JsonConvert.DeserializeObject<List<Currency>>(responseClient.Value.ToString());
                }
            }
            return View(currenc);
        }

        // GET: Currency/Details/5
        public async Task< ActionResult> Details(int id)
        {
            currency = new Currency();
            responseClient = new Response();

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"https://localhost:44331/General/Currencys/ObtenerUno?id={id}");
                if (response.IsSuccessStatusCode)
                {
                    var str = await response.Content.ReadAsStringAsync();
                    responseClient = JsonConvert.DeserializeObject<Response>(str);
                }
                if (responseClient.Success)
                {
                    currency = JsonConvert.DeserializeObject<Currency>(responseClient.Value.ToString());
                }
            }
            return View(currency);
        }

        // GET: Currency/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Currency/Create
        [HttpPost]
        public async Task< ActionResult >Create(FormCollection collection)
        {
            try
            {
                currency = new Currency();
                responseClient = new Response();

                using (var client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(collection);
                    var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync($"https://localhost:44331/General/Currencys/CrearUno", stringContent);

                    string resultContent = response.Content.ReadAsStringAsync().Result;

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Currency/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Currency/Edit/5
        [HttpPost]
        public  async Task<ActionResult> Edit(int id, FormCollection collection)
        {
            try
            {
                currency = new Currency();
                responseClient = new Response();

                using (var client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(collection);
                    var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PutAsync($"https://localhost:44331/General/Currencys/ActualizarUno", stringContent);

                    string resultContent = response.Content.ReadAsStringAsync().Result;

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Currency/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Currency/Delete/5
        [HttpPost]
        public async Task< ActionResult> Delete(int id, FormCollection collection)
        {
            try
            {
                responseClient = new Response();

                using (var client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(collection);
                    var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.DeleteAsync($"https://localhost:44331/General/Currencys/BorrarUno?id={id}");

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
