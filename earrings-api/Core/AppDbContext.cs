using Azure;
using Microsoft.EntityFrameworkCore;

namespace earrings_api.Shared
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> opciones) : base(opciones)
        {

        }

        //Entidades / Entities
        //public DbSet<TipoMovimiento> TipoMovimiento { get; set; }
    }
}
