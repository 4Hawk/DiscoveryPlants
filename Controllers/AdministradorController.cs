using System.Threading;
using System.Data.Common;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks.Dataflow;
using System.Runtime.CompilerServices;
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

        

        public IActionResult IndexCategoria()
        {
          var CatPlantas = _context.CategoriasTab.ToList();
          ViewBag.NombreCat= CatPlantas;
          return View();
        }

      [HttpPost]
        public IActionResult IndexCategoria( Categorias ca)
        {
          
          if (ModelState.IsValid) {
                _context.Add(ca);
                _context.SaveChanges();
                TempData["mensaje"] = "La Categoria de Planta fue registrada exitosamente";
                return RedirectToAction("indexcategoria","administrador");
            }
            return View(ca);
          
        }


        public IActionResult VistaCategoriaAct(int codigo)
        {
          var  cate = _context.CategoriasTab.Find(codigo);
          
          ViewBag.CategoriaE = cate;
          return View();
        }
    
        [HttpPost]
        public IActionResult ActualizarCategoria(int codigo, Categorias li)
        {
          var  actu = _context.CategoriasTab.Find(codigo);
          actu.Nombre  = li.Nombre;
          _context.SaveChanges();
          return RedirectToAction("IndexCategoria","Administrador");
          
        }
        

      


          public IActionResult IndexOng()
          {
            var ongs = _context.OngsTab.ToList();
            ViewBag.Ongs= ongs;
            return View();
            
          
          }

          [HttpPost]
          public IActionResult IndexOng(Ongs cc)
          {
            
            if (ModelState.IsValid) {
                  _context.Add(cc);
                  _context.SaveChanges();
                  TempData["mensaje"] = "La Categoria de Planta fue registrada exitosamente";
                  return RedirectToAction("IndexOng","administrador");
              }
              return RedirectToAction("IndexOng","Administrador");
            
          }

                  public IActionResult VistaOngAct(int codigo)
                  {
                    var onge = _context.OngsTab.Find(codigo);
                    ViewBag.OngE = onge;
                    return View();
                  }
                  [HttpPost]
                  public IActionResult ActualizarOng(int codigo,Ongs on)
                  {
                    var  actu= _context.OngsTab.Find(codigo);
                    actu.Nombre=on.Nombre;
                    actu.Correo=on.Correo;
                    actu.Direccion=on.Direccion;
                    actu.Telefono=on.Telefono;
                    actu.CuentaB=on.CuentaB;
                    _context.SaveChanges();
                    return RedirectToAction("IndexOng","Administrador");
                    
                  }
      




        public IActionResult EliminarOng(int codigo)
        {
          var loc=_context.OngsTab.Find(codigo);
          _context.Remove(loc);
          _context.SaveChanges();
          
          return RedirectToAction("IndexOng","Administrador");
        }

        public IActionResult EliminarCat(int codigo)
        {
          var loc=_context.CategoriasTab.Find(codigo);
          _context.Remove(loc);
          _context.SaveChanges();
          
          return RedirectToAction("IndexCategoria","Administrador");
        }
        

        public IActionResult EliminarPlanta(int codigo)
        {
          var plant=_context.PlantasTab.Find(codigo);
          _context.Remove(plant);
          _context.SaveChanges();
          return RedirectToAction("ListadoGeneral","Home");
        }
      

    }
}