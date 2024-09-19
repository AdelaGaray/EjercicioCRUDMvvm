#pragma warning disable IDE0005 // El uso de la directiva no es necesario.
using EjercicioCRUDMvvm.Models;

namespace EjercicioCRUDMvvm.Data
{
#pragma warning disable CS0659 // El tipo reemplaza a Object.Equals(object o), pero no reemplaza a Object.GetHashCode()
    public class AppDbContext : DbContext
#pragma warning restore CS0659 // El tipo reemplaza a Object.Equals(object o), pero no reemplaza a Object.GetHashCode()
    {
        public AppDbContext()
        {
        }
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de agregar el modificador "required" o declararlo como un valor que acepta valores NULL.
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de agregar el modificador "required" o declararlo como un valor que acepta valores NULL.
        {
        }

        public AppContext(DbSet<Proveedor> proveedores)
        {
            Proveedores = proveedores;
        }

        public DbSet<Proveedor> Proveedores { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is AppDbContext context &&
                   EqualityComparer<DbSet<Proveedor>>.Default.Equals(Proveedores, context.Proveedores);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=proveedores.db");
        }

#pragma warning disable CS1998 // El método asincrónico carece de operadores "await" y se ejecutará de forma sincrónica
        internal async Task SaveChangesAsync()
#pragma warning restore CS1998 // El método asincrónico carece de operadores "await" y se ejecutará de forma sincrónica
        {
            throw new NotImplementedException();
        }
    }
}
