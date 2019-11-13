using System.ComponentModel.DataAnnotations;

namespace DiscoveryPlants.Models
{
    public class Ongs
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }

        [Required]
        [EmailAddress]
        public string Correo { get; set; }

        [Required]
        public string Direccion { get; set; }
        [Required]
        public int Telefono { get; set; }

        public int CuentaB { get; set; }
    }
}