using DiscoveryPlants.Models;

using Microsoft.AspNetCore.Mvc;

namespace DiscoveryPlants.Controllers
{
    public class AdministradorController:Controller
    {
        private DiscoveryContext _context;

        public AdministradorController(DiscoveryContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
          //TODO: Implement Realistic Implementation
          return View();
        }

      
        public IActionResult RegistrarCategoria()
        {
          //TODO: Implement Realistic Implementation
          return View();
        }

        [HttpPost]
        public IActionResult RegistrarCategoria(Categorias ca)
        {
          //TODO: Implement Realistic Implementation
          return View();
        }


        public IActionResult RegistrarOng()
        {
          //TODO: Implement Realistic Implementation
          return View();
        }

        [HttpPost]
        public IActionResult RegistrarOng(Ongs on)
        {
          //TODO: Implement Realistic Implementation
          return View();
        }
    }
}