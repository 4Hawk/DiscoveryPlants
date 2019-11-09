using System.ComponentModel.DataAnnotations;

namespace DiscoveryPlants.Models
{
    public class Plantas
    {
        public int PlantaId { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Foto{get;set;}
        [Required]
        public string Descripcion{get;set;}
        public int CategoriaId { get; set; }
    }
}