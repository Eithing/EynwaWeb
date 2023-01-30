using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EynwaWeb.Models;
using EynwaWeb.Models.ContextSelector;

namespace EynwaWeb.Controllers
{
    public class ContextSelectorController : Controller
    {
        private readonly ILogger<ContextSelectorController> _logger;

        public ContextSelectorController(ILogger<ContextSelectorController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<ContextItem> _contextItemList = new List<ContextItem>{
                new ContextItem { Description = "oui", Image = "https://ethlan.fr/img/jeux/10771.jpg", Title = "CS:GO"},
                new ContextItem { Description = "non", Image = "http://www.pedagojeux.fr/wp-content/uploads/2019/11/1280x720_LoL.jpg", Title = "LOL"},
                new ContextItem { Description = "jsp", Image = "https://www.breakflip.com/uploads/VALORANT/Vignettes/valorant-ranked-parties-classees-date-sortie.jpg", Title = "VALORANT"}
            };
            return View(_contextItemList);
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
