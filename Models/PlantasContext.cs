using Microsoft.EntityFrameworkCore;

namespace DiscoveryPlants.Models
{
    public class PlantasContext:DbContext
    {
        public PlantasContext(DbContextOptions<PlantasContext> o): base(o){
        }
        
    }
}