using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TemperatureWebsite.Models;

namespace TemperatureWebsite.Controllers
{
    public class TemperatureController : Controller
    {

        
        public HttpClient Client { get; set; }

        public TemperatureController(HttpClient client)
        {
            Client = client;
        }
        
        // GET: Temperature
        public async Task<ActionResult> Index()
        {
            HttpResponseMessage response = await Client.GetAsync("https://localhost:50912/api/temperature");

            // (if status is not between 200-299 (for success))
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Error", "Home");
            }

            // get the whole response body (second await)
            string responseBody = await response.Content.ReadAsStringAsync();

            // this is a string
            // Newtonsoft JSON or Json.NET
            List<TemperatureRecord> temperature = JsonConvert.DeserializeObject<List<TemperatureRecord>>(responseBody);


            return View();
        }

        // GET: Temperature/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Temperature/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Temperature/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Temperature/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Temperature/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Temperature/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Temperature/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}