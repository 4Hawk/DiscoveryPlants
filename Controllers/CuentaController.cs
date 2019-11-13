using System.Linq;
using DiscoveryPlants.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DiscoveryPlants.Controllers
{
    public class CuentaController : Controller
    {
        private DiscoveryContext _context;
        private SignInManager<IdentityUser> _sim;
        private UserManager<IdentityUser> _um;
        private RoleManager<IdentityRole> _rm;
        public CuentaController(
            DiscoveryContext c,  
            SignInManager<IdentityUser> s,
            UserManager<IdentityUser> um,
            RoleManager<IdentityRole> rm) {

            _context = c;
            _sim = s;
            _um = um;
            _rm = rm;
        }

        

        [HttpPost]
        public IActionResult AsociarRol(string usuario, string rol) {
            var user = _um.FindByIdAsync(usuario).Result;

            var resultado = _um.AddToRoleAsync(user, rol).Result;
            TempData["mensaje"] = "El Rol fue asociado exitosamente";  
            return RedirectToAction("paneldba", "cuenta");
        }

        

        [HttpPost]
        public IActionResult CrearRol(string nombre)
        {
            var rol = new IdentityRole();
            rol.Name = nombre;

            var resultado = _rm.CreateAsync(rol).Result;
            
            TempData["mensaje"] = "El Rol fue creado exitosamente";            

            return RedirectToAction("paneldba","cuenta");
        }

        
        public IActionResult AccesoDenied() {
            return View();
        }
        

        public IActionResult Registrarse()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrarse(CrearUsuarios model) {
            if (ModelState.IsValid) {
                // Guardar datos del modelo en la tabla usuarios
                var usuario = new IdentityUser();
                usuario.UserName = model.Correo;
                usuario.Email = model.Correo;

                IdentityResult resultado = _um.CreateAsync(usuario, model.ContraseñaP).Result;
                var r = _um.AddToRoleAsync(usuario, "Usuario").Result;


                if (resultado.Succeeded) {
                    return RedirectToAction("index", "home");
                }
                else {
                    foreach (var item in resultado.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }                
            }

            return View(model);
        }


        public IActionResult IniciarSesion() {
            return View();
        }

        [HttpPost]
        public IActionResult IniciarSesion(Logueo model) {

            if (ModelState.IsValid) {

             
                var resultado = _sim.PasswordSignInAsync(model.Correo, model.Password, true, false).Result;

                if (resultado.Succeeded) {

                    return RedirectToAction("index", "home");
                }
                else {
                    
                    ModelState.AddModelError("", "Datos incorrectos");
                }
            }        

            return View(model);
        }

        public IActionResult Salir() {
            _sim.SignOutAsync();

            return RedirectToAction("index", "home");
        }


        public IActionResult Paneldba()
        {
            ViewBag.Usuarios = _um.Users.ToList();
            ViewBag.Roles = _rm.Roles.ToList();
          
            return View();
        }



    }
}