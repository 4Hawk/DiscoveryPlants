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

            var Categorias = _context.CategoriasTab.ToList();
            ViewBag.Categorias=Categorias;
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
            var Plantas = _context.PlantasTab.OrderByDescending(x=>x.FechaRegistro).Take(3).ToList();
            var viewModel = new Listas();
            viewModel.ListPlantas = Plantas;
            return View(viewModel);
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
