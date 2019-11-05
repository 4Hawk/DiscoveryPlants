using System.ComponentModel.DataAnnotations;

namespace DiscoveryPlants.Models
{
    public class Logueo
    {
        [Required]
        [EmailAddress]
        public string Correo { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}