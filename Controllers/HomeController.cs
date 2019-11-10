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
        public IActionResult IngresarPlanta (){

            var Planta = _context.PlantasTab.ToList();
            ViewBag.Planta=Planta;
            return View();
        }

        [HttpPost]
        public IActionResult IngresarPlanta (Plantas m){
            if(ModelState.IsValid){
                _context.Add(m);
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            
            return View(m);
        }


        public IActionResult Donar()
        {
            return View();
        }

        public IActionResult ListadoP()
        {
            var ter = _context.PlantasTab.Take(3).ToList().OrderBy(x=>x.FechaRegistro);
            var viewModel = new Listas();
            viewModel.ListPlantas = ter;
            return View(ter);
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
            ViewBag.Categorias = _context.CategoriasTab.ToList();
            return View();
        }   

        [HttpPost]
        public IActionResult PanelUsuario(Plantas pa)
        {
            if(ModelState.IsValid){
                _context.Add(pa);
                _context.SaveChanges();
                return RedirectToAction("ListadoP","Home");
            }
            ViewBag.Categorias = _context.CategoriasTab.ToList();
            return View(pa);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
