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
    public class UserController : Controller
    {
        User usuario;
        List<User> usuarioN;
        Response responseClient;
        // GET: User
        public async Task<ActionResult> Index()
        {
            usuarioN = new List<User>();
            responseClient = new Response();

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("https://localhost:44331/General/User/ObtenerTodas");
                if (response.IsSuccessStatusCode)
                {
                    var str = await response.Content.ReadAsStringAsync();
                    responseClient = JsonConvert.DeserializeObject<Response>(str);
                }
                if (responseClient.Success)
                {
                    usuarioN = JsonConvert.DeserializeObject<List<User>>(responseClient.Value.ToString());
                }
            }
            return View(usuarioN);
        }

        // GET: User/Details/5
        public async Task<ActionResult> Details(int id)
        {
            usuario = new User();
            responseClient = new Response();

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"https://localhost:44331/General/User/ObtenerUno?id={id}");
                if (response.IsSuccessStatusCode)
                {
                    var str = await response.Content.ReadAsStringAsync();
                    responseClient = JsonConvert.DeserializeObject<Response>(str);
                }
                if (responseClient.Success)
                {
                    usuario = JsonConvert.DeserializeObject<User>(responseClient.Value.ToString());
                }
            }
            return View(usuario);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public async Task<ActionResult >Create(FormCollection collection)
        {
            try
            {
                usuario = new User();
                responseClient = new Response();

                using (var client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(collection);
                    var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync($"https://localhost:44331/General/User/CrearUno", stringContent);

                    string resultContent = response.Content.ReadAsStringAsync().Result;

                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        public async Task<ActionResult >Edit(int id, FormCollection collection)
        {
            try
            {
                usuario = new User();
                responseClient = new Response();

                using (var client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(collection);
                    var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PutAsync($"https://localhost:44331/General/User/ActualizarUno", stringContent);

                    string resultContent = response.Content.ReadAsStringAsync().Result;

                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
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

                    HttpResponseMessage response = await client.DeleteAsync($"https://localhost:44331/General/User/BorrarUno?id={id}");

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
