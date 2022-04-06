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
    public class RolUsersController : Controller
    {
        RolUsers rolUser;
        List<RolUsers> rolUsuario;
        Response responseClient;
        // GET: RolUsers
        public async Task<ActionResult> Index()
        {
            rolUsuario = new List<RolUsers>();
            responseClient = new Response();

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://localhost:44331/General/RolUsers/ObtenerTodas");
                if (response.IsSuccessStatusCode)
                {
                    var str = await response.Content.ReadAsStringAsync();
                    responseClient = JsonConvert.DeserializeObject<Response>(str);
                }
                if (responseClient.Success)
                {
                    rolUsuario = JsonConvert.DeserializeObject<List<RolUsers>>(responseClient.Value.ToString());
                }
            }
            return View(rolUsuario);
        }

        // GET: RolUsers/Details/5
        public async Task<ActionResult> Details(int id)
        {
            rolUser = new RolUsers();
            responseClient = new Response();

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"https://localhost:44331/General/RolUsers/ObtenerUno?id={id}");
                if (response.IsSuccessStatusCode)
                {
                    var str = await response.Content.ReadAsStringAsync();
                    responseClient = JsonConvert.DeserializeObject<Response>(str);
                }
                if (responseClient.Success)
                {
                    rolUser = JsonConvert.DeserializeObject<RolUsers>(responseClient.Value.ToString());
                }
            }
            return View(rolUser);
        }

        // GET: RolUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RolUsers/Create
        [HttpPost]
        public async Task<ActionResult> Create(FormCollection collection)
        {
            try
            {
                rolUser = new RolUsers();
                responseClient = new Response();

                using (var client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(collection);
                    var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync($"https://localhost:44331/General/RolUsers/CrearUno", stringContent);

                    string resultContent = response.Content.ReadAsStringAsync().Result;

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RolUsers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RolUsers/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, FormCollection collection)
        {
            try
            {
                rolUser = new RolUsers();
                responseClient = new Response();

                using (var client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(collection);
                    var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PutAsync($"https://localhost:44331/General/RolUsers/ActualizarUno", stringContent);

                    string resultContent = response.Content.ReadAsStringAsync().Result;

                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RolUsers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RolUsers/Delete/5
        [HttpPost]
        public async Task<ActionResult >Delete(int id, FormCollection collection)
        {
            try
            {
                rolUser = new RolUsers();
                responseClient = new Response();

                using (var client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(collection);
                    var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.DeleteAsync($"https://localhost:44331/General/RolUsers/BorrarUno?id={id}");

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
