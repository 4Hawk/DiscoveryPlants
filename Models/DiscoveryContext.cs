
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DiscoveryPlants.Models
{
    public class DiscoveryContext:IdentityDbContext
    {

        public DbSet<Plantas> PlantasTab {get;set;}
        public DbSet<Ongs> OngsTab {get;set;}
        public DbSet<Categorias> CategoriasTab {get;set;}

       

        public DiscoveryContext(DbContextOptions<DiscoveryContext> o): base(o){
        }
        
    }
}