using System.ComponentModel.DataAnnotations;
namespace DiscoveryPlants.Models
{
    public class CrearUsuarios
    {
        [Required]
        public string Nombre { get; set; }
        
        [Required]
        public string Apellido { get; set; }

        
        [Required]
        [EmailAddress]
        public string Correo { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string ContraseñaP{ get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("ContraseñaP", ErrorMessage="Las contraseñas con coinciden")]
        public string ContraseñaS{ get; set; }
    }
}