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


        [HttpPost]
        public IActionResult MensajeDonar(int code)
            {
                var codigo = _context.OngsTab.Where(x=>x.Id==code).Select(z=>z.CuentaB);
                TempData["cod"] = "La cuenta Bancaria de la ONG elegida es:"+codigo;
                return RedirectToAction("Donar","Home");  
            }

        public IActionResult Donar()
        {
            var listaCat = _context.OngsTab.ToList();
            return View(listaCat);
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
            var Plantas = _context.PlantasTab.OrderByDescending(x=>x.FechaRegistro).ToList();
            var viewModel = new Listas();
            viewModel.ListPlantas = Plantas;
            return View(viewModel);
        }

        public IActionResult SobreNosotros()
        {
            return View();
        }

        public IActionResult PlantasDoc(int codigo)
        {
            var planta= _context.PlantasTab.Where(x=>x.Id==codigo).ToList();
            var viewModel = new Listas();
            viewModel.ListPlantas = planta;
            return View(viewModel);
        }
        

        public IActionResult PanelUsuario()
        {
           
            return View();
        }   

        [HttpPost]
        public IActionResult PanelUsuario(Plantas pa)
        {
            
            return View(pa);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
