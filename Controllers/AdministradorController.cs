using System.Security.AccessControl;
using System;
using DiscoveryPlants.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace DiscoveryPlants.Controllers
{
    [Authorize(Roles="dba")]
    public class AdministradorController:Controller
    {

        
        private DiscoveryContext _context;

        public AdministradorController(DiscoveryContext context)
        {
            _context = context;
        }

        

      public IActionResult RegistrarCategoria()
      {
        var CatPlantas = _context.CategoriasTab.ToList();
        ViewBag.NombreCat= CatPlantas;
        return View();
      }


        

        [HttpPost]
        public IActionResult RegistrarCategoria(Categorias ca)
        {
          if (ModelState.IsValid) {
                _context.Add(ca);
                _context.SaveChanges();
                TempData["mensaje"] = "La Categoria de Planta fue registrada exitosamente";
                return RedirectToAction("registrarcategoria","administrador", new{p=1});
            }
            return View(ca);
          
        }


        public IActionResult RegistrarOng()
        {
          //TODO: Implement Realistic Implementation
          
          return View();
        }

        [HttpPost]
        public IActionResult RegistrarOng(Ongs on)
        {
          if (ModelState.IsValid) {
                _context.Add(on);
                _context.SaveChanges();
                TempData["mensaje"] = "La ONG fue registrada satisfactoriamente";
                return RedirectToAction("registrarong","administrador");
            }
            return View(on);
          
        }

        public IActionResult EliminarCat(int codigo)
        {
          var loc=_context.CategoriasTab.Find(codigo);
          _context.Remove(loc);
          _context.SaveChanges();
          
          return View();
        }
    }
}