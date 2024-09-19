namespace EjercicioCRUDMvvm.Data
{
    public class DbContextBase
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=proveedores.db");
        }
    }
}