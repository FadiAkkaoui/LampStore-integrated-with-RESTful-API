using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDBAPI.Controllers
{
    public class FelhanteringsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
