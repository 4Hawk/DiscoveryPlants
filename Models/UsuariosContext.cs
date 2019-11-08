using Microsoft.EntityFrameworkCore;

namespace DiscoveryPlants.Models
{
    public class UsuariosContext:DbContext
    {
        public UsuariosContext(DbContextOptions<UsuariosContext> o): base(o){
        }
    }
}