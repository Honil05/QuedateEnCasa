using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Tarea34.Models;
using Tarea34.Servicio;

namespace Tarea34.Controllers
{
    public class CedulaController : Controller
    {

        String baseUrl = "http://173.249.49.169:88/";
        private readonly ICedulaServicies cedulaServicies;
        public CedulaController(ICedulaServicies CedulaS) {

            cedulaServicies = CedulaS;
        
        }

        public async Task<IActionResult> Index() {

            var items = await cedulaServicies.GetIncompleteItemsAsync();
            var model = new CedView()
            {
                Ced = items
            };
            return View(model);
        }

        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Añadir(String Cedula, String correo, String telefono)
        {
            cedula newItem = new cedula();
            using (var client = new HttpClient())
            {


                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("aplication/json"));

                HttpResponseMessage res = await client.GetAsync("api/test/consulta/" + Cedula);

                if (res.IsSuccessStatusCode)
                {
                    string resp = res.Content.ReadAsStringAsync().Result;

                    if (resp != "0")
                    {
                        newItem = JsonConvert.DeserializeObject<cedula>(resp);
                    }
                    else
                    {
                        return RedirectToAction("NoExiste", "Cedula");
                    }
                }
                else
                {
                    return RedirectToAction("ErrorPage", "Cedula");
                }
            }
            if (newItem.Ok != false)
            {
                if (!ModelState.IsValid)
                {
                    return RedirectToAction("Index");
                }
                var successful = await cedulaServicies.AddItemAsync(newItem, correo, telefono);

                if (!successful)
                {
                    return BadRequest("No se ha podido añadir");
                }
            }


            return RedirectToAction("Index");

        }



        public ActionResult NoExiste()
        {
            return View();
        }
        public ActionResult ErrorPage()
        {
            return View();
        }









    }
}
