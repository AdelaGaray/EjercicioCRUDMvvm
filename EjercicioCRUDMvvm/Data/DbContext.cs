namespace EjercicioCRUDMvvm.Data
{
    public class DbContext : DbContextBase
    {
        public DbContext(DbContextOptions<AppDbContext> options)
        {
        }
    }
}