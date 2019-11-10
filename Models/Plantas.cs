using System;
using System.ComponentModel.DataAnnotations;


namespace DiscoveryPlants.Models
{
    public class Plantas
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }

        public string Usos { get; set; }
        [Required]
        public string Caracteristicas { get; set; }
        [Required]
        public string Foto{get;set;}

        public string Ubicacion { get; set; }

        public Categorias CategoriaAsig { get; set; }
        public string InfoAdicional{get;set;}
        public int CategoriaId { get; set; }
        public DateTime FechaRegistro { get; set; }

        public Plantas()
        {
           FechaRegistro = DateTime.Now;
        }
    }
}