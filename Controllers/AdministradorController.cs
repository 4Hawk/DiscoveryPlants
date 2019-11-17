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
        public IActionResult RegistrarCategoria(int codigo, Categorias l)
        {
          var  actu= _context.CategoriasTab.Find(codigo);
          actu.Nombre=l.Nombre;
          
          _context.SaveChanges();
          return RedirectToAction("RegistrarCategoria","Administrador");
          
        }
        public IActionResult RegistrarCategoria2()
      {
        
        return View();
      }

        [HttpPost]
        public IActionResult RegistrarCategoria2( Categorias ca)
        {
          
          if (ModelState.IsValid) {
                _context.Add(ca);
                _context.SaveChanges();
                TempData["mensaje"] = "La Categoria de Planta fue registrada exitosamente";
                return RedirectToAction("registrarcategoria","administrador", new{p=1});
            }
            return RedirectToAction("RegistrarCategoria","Administrador");
          
        }


        public IActionResult RegistrarOng()
        {
          var ongs = _context.OngsTab.ToList();
          ViewBag.Ongs= ongs;
          return View();
          
        
        }

        [HttpPost]
        public IActionResult RegistrarOng(int codigo,Ongs on)
        {
          var  actu= _context.OngsTab.Find(codigo);
          actu.Nombre=on.Nombre;
          actu.Correo=on.Correo;
          actu.Direccion=on.Direccion;
          actu.Telefono=on.Telefono;
          actu.CuentaB=on.CuentaB;
          _context.SaveChanges();
          return RedirectToAction("RegistrarOng","Administrador");
          
        }
        public IActionResult RegistrarOng2()
      {
        
        return View();
      }

        [HttpPost]
        public IActionResult RegistrarOng2(Ongs cc)
        {
          
          if (ModelState.IsValid) {
                _context.Add(cc);
                _context.SaveChanges();
                TempData["mensaje"] = "La Categoria de Planta fue registrada exitosamente";
                return RedirectToAction("registrarOng","administrador", new{p=1});
            }
            return RedirectToAction("RegistrarOng","Administrador");
          
        }

        public IActionResult EliminarOn(int codigo)
        {
          var loc=_context.OngsTab.Find(codigo);
          _context.Remove(loc);
          _context.SaveChanges();
          
          return RedirectToAction("RegistrarOng","Administrador");
        }
        public IActionResult EliminarCat(int codigo)
        {
          var loc=_context.CategoriasTab.Find(codigo);
          _context.Remove(loc);
          _context.SaveChanges();
          
          return RedirectToAction("RegistrarCategoria","Administrador");
        }
        

      

    }
}