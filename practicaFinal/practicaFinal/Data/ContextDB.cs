using Microsoft.EntityFrameworkCore;
using practicaFinal.Models;

namespace practicaFinal.Data
{
    public class ContextDB: DbContext
    {

        public ContextDB(DbContextOptions<ContextDB> options) : base(options)
        {

        }


        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Ciudad> Ciduades { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
    }
}
