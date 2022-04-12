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
    public class CompanyController : Controller
    {
        Company company;
        List<Company> companies;
        Response responseClient;
        // GET: Company
        public async Task<ActionResult> Index()
        {
            companies = new List<Company>();
            responseClient = new Response();

			try
			{
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync("https://localhost:44331/General/Compania/ObtenerTodas");
                    if (response.IsSuccessStatusCode)
                    {
                        var str = await response.Content.ReadAsStringAsync();
                        responseClient = JsonConvert.DeserializeObject<Response>(str);
                    }
                    if (responseClient.Success)
                    {
                        companies = JsonConvert.DeserializeObject<List<Company>>(responseClient.Value.ToString());
                    }
                }
            }
			catch (Exception error)
			{
                ViewBag.ErrorInfo = "Error al intentar conectar con servidor de datos.";
                ViewBag.ErrorMessage = error.Message;
                ViewBag.InnerException = error.InnerException;
                ViewBag.StackTrace = error.StackTrace;
                return View("Error");
            }
            return View(companies);
        }

        // GET: Company/Details/5
        public async Task<ActionResult> Details(int id)
        {
            company = new Company();
            responseClient = new Response();

            using (var client = new HttpClient())
            { 
                HttpResponseMessage response = await client.GetAsync($"https://localhost:44331/General/Compania/ObtenerUno?id={id}");
                if (response.IsSuccessStatusCode)
                {
                    var str = await response.Content.ReadAsStringAsync();
                    responseClient = JsonConvert.DeserializeObject<Response>(str);
                }
                if (responseClient.Success)
                {
                    company = JsonConvert.DeserializeObject<Company>(responseClient.Value.ToString());
                }
            }
            return View(company);
        }

        // GET: Company/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Company/Create
        [HttpPost]
        public async Task<ActionResult> Create(FormCollection collection)
        {
            try
            {
                company = new Company();
                responseClient = new Response();

                using (var client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(collection);
                    var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync($"https://localhost:44331/General/Compania/CrearUno", stringContent);
 
                    string resultContent = response.Content.ReadAsStringAsync().Result;
 
                } 

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Company/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Company/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, FormCollection collection)
        {
            try
            {
                company = new Company();
                responseClient = new Response();

                using (var client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(collection);
                    var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PutAsync($"https://localhost:44331/General/Compania/ActualizarUno", stringContent);

                    string resultContent = response.Content.ReadAsStringAsync().Result;

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Company/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Company/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, FormCollection collection)
        {
            try
            {
                company = new Company();
                responseClient = new Response();

                using (var client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(collection);
                    var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.DeleteAsync($"https://localhost:44331/General/Compania/BorrarUno?id={id}");

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
