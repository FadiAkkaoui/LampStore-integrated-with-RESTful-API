using LabbASPclient.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LabbASPclient.Controllers
{
    public class APIController : Controller
    {
        public async Task<IActionResult> Index()
        {
            try
            {
                List<ArtikelAPI> ArtikelList = new List<ArtikelAPI>();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync("http://localhost:54353/Artiklars"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        ArtikelList = JsonConvert.DeserializeObject<List<ArtikelAPI>>(apiResponse);
                    }
                }
                return View(ArtikelList);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return RedirectToAction("Felhantering", "Artiklars");
            }
        }
    }
}
