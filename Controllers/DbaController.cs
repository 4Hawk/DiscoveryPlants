using DiscoveryPlants.Models;
using DiscoveryPlants_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace DiscoveryPlants_1.Controllers
{
    public class DbaController:Controller
    {
        private DiscoveryContext _context;

        public DbaController(DiscoveryContext context)
        {
            _context = context;
        }

        public IActionResult IndexPanel()
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