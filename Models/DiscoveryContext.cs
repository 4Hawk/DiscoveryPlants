using DiscoveryPlants_1.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DiscoveryPlants.Models
{
    public class DiscoveryContext:IdentityDbContext
    {

        DbSet<Plantas> PlantasTab {get;set;}
        DbSet<Ongs> OngsTab {get;set;}
        DbSet<Categorias> CategoriasTab {get;set;}

        public DiscoveryContext(DbContextOptions<DiscoveryContext> o): base(o){
        }
        
    }
}