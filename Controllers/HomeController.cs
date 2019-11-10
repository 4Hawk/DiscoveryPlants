using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DiscoveryPlants.Models;

namespace DiscoveryPlants.Controllers
{
    public class HomeController : Controller
    {
        private DiscoveryContext _context;

        public HomeController(DiscoveryContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        

        public IActionResult Donar()
        {
            return View();
        }

        public IActionResult ListadoP()
        {
            return View();
        }

        public IActionResult Consejos()
        {
            return View();
        }

        public IActionResult ListadoGeneral()
        {
            return View();
        }

        public IActionResult SobreNosotros()
        {
            return View();
        }

        public IActionResult PlantasDoc()
        {
            return View();
        }


        public IActionResult PanelUsuario()
        {
            ViewBag.CategoriasTab = _context.CategoriasTab.ToList();
            return View();
        }   



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
