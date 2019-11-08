using Microsoft.AspNetCore.Mvc;

namespace DiscoveryPlants.Controllers
{
    public class PlantasController : Controller
    {
        public IActionResult RegistrarPlanta()
        {
            return View();
        }

        public IActionResult RegistrarCategoria(){
            return View();
        }
    }
}