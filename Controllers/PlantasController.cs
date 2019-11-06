using Microsoft.AspNetCore.Mvc;

namespace DiscoveryPlants.Controllers
{
    public class PlantasController : Controller
    {
        public IActionResult RegistarPlanta()
        {
            return View();
        }
    }
}