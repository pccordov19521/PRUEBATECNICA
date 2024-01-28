using APIREST.Models;
using Microsoft.EntityFrameworkCore;

namespace APIREST.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Cuenta> Cuenta { get; set; }
        public DbSet<Movimientos> Movimientos { get; set; }

        public DbSet<Reporte> Reporte { get; set; }
    


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

    

    }
}
