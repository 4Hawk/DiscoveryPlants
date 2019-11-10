using System.Security.AccessControl;
using System;
using DiscoveryPlants.Models;
using Microsoft.AspNetCore.Identity;
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

        

      
        

        [HttpPost]
        public IActionResult RegistrarCategoria(Categorias ca)
        {
          if (ModelState.IsValid) {
                _context.Add(ca);
                _context.SaveChanges();
                return RedirectToAction("cuenta","paneldba");
            }
            return View(ca);
          
        }


        

        [HttpPost]
        public IActionResult RegistrarOng(Ongs on)
        {
          if (ModelState.IsValid) {
                _context.Add(on);
                _context.SaveChanges();
                return RedirectToAction("cuenta","paneldba");
            }
            return View(on);
          
        }
    }
}