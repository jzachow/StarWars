using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StarWarsAPIInterview.Models;

namespace StarWarsAPIInterview.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly StarWarsModel _starWarsModel;

        public HomeController(ILogger<HomeController> logger, StarWarsModel starWarsModel)
        {
            _logger = logger;
            _starWarsModel = starWarsModel;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Planet()
        {
            await _starWarsModel.OnGet();
            return View(_starWarsModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
