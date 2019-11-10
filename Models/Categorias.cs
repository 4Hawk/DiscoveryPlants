using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DiscoveryPlants.Models;

namespace DiscoveryPlants.Models
{
    public class Categorias
    {
        public int Id { get; set; }

        [Required]
        [Display(Name="Nombre de la categoría")]
        public string Nombre { get; set; }

        public List<Plantas> LPlantas { get; set; }
        
    }
}