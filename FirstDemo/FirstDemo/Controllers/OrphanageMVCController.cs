using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FirstDemo.Models;
using System.Web.Mvc;
using System.Net.Http;

namespace FirstDemo.Controllers
{
    public class OrphanageMVCController : Controller
    {
        // GET: OrphanageMVC
        public ActionResult Index()
        {
            IEnumerable<orphanageRegistration1> orpObj = null;
            HttpClient hc = new HttpClient();

            hc.BaseAddress = new Uri("https://localhost:44314/api/Orphanage");
            var consumeapi = hc.GetAsync("Orphanage");

            consumeapi.Wait();

            var readdata = consumeapi.Result;

            if (readdata.IsSuccessStatusCode)
            {
                var displaydata = readdata.Content.ReadAsAsync<IList<orphanageRegistration1>>();

                displaydata.Wait();

                orpObj = displaydata.Result;
            }
            return View(orpObj);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(orphanageRegistration1 orp)
        {
            HttpClient hc = new HttpClient();

            hc.BaseAddress = new Uri("https://localhost:44314/api/Orphanage");
            var consumeapi = hc.PostAsJsonAsync("Orphanage",orp);

            consumeapi.Wait();

            var readdata = consumeapi.Result;

            if (readdata.IsSuccessStatusCode)
            {


                return RedirectToAction("Index");
            }
            return View("Create");
        }
    }
}