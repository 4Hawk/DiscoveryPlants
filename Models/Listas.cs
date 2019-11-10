using System.Collections.Generic;
using DiscoveryPlants.Models;

namespace DiscoveryPlants.Models
{
    public class Listas
    {
        public IEnumerable<Plantas> ListPlantas { get; set; }
        public List<Categorias> ListCategorias { get; set; }
    }
}