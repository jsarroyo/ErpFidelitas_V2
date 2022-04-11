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
    public class PersonTypeController : Controller
    {
        PersonType personType;
        List<PersonType> persont;
        Response responseClient;
        // GET: PersonType
        public async Task< ActionResult> Index()
        {
            persont = new List<PersonType>();
            responseClient = new Response();

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://localhost:44331/General/PersonsType/ObtenerTodas");
                if (response.IsSuccessStatusCode)
                {
                    var str = await response.Content.ReadAsStringAsync();
                    responseClient = JsonConvert.DeserializeObject<Response>(str);
                }
                if (responseClient.Success)
                {
                    persont = JsonConvert.DeserializeObject<List<PersonType>>(responseClient.Value.ToString());
                }
            }
            return View(persont);
        }

        // GET: PersonType/Details/5
        public async Task<ActionResult> Details(int id)
        {
            personType = new PersonType();
            responseClient = new Response();

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"https://localhost:44331/General/PersonsType/ObtenerUno?id={id}");
                if (response.IsSuccessStatusCode)
                {
                    var str = await response.Content.ReadAsStringAsync();
                    responseClient = JsonConvert.DeserializeObject<Response>(str);
                }
                if (responseClient.Success)
                {
                    personType = JsonConvert.DeserializeObject<PersonType>(responseClient.Value.ToString());
                }
            }
            return View(personType);
        }

        // GET: PersonType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonType/Create
        [HttpPost]
        public async Task<ActionResult> Create(FormCollection collection)
        {
            try
            {
                personType = new PersonType();
                responseClient = new Response();

                using (var client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(collection);
                    var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync($"https://localhost:44331/General/PersonsType/CrearUno", stringContent);

                    string resultContent = response.Content.ReadAsStringAsync().Result;

                }
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
        public async Task<ActionResult> Edit(int id, FormCollection collection)
        {
            try
            {
                personType = new PersonType();
                responseClient = new Response();

                using (var client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(collection);
                    var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PutAsync($"https://localhost:44331/General/PersonsType/ActualizarUno", stringContent);

                    string resultContent = response.Content.ReadAsStringAsync().Result;

                }
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
        public async Task<ActionResult> Delete(int id, FormCollection collection)
        {
            try
            {
                personType = new PersonType();
                responseClient = new Response();

                using (var client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(collection);
                    var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.DeleteAsync($"https://localhost:44331/General/PersonsType/BorrarUno?id={id}");

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
