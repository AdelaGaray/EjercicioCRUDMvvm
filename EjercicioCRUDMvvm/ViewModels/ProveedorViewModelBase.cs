using EjercicioCRUDMvvm.Data;

namespace EjercicioCRUDMvvm.ViewModels
{
    public class ProveedorViewModelBase
    {

        private async Task DeleteProveedor(AppDbContext _dbContext)
        {
            if (SelectedProveedor != null)
            {
                object value = _dbContext.Proveedores.Remove(SelectedProveedor);
                await _dbContext.SaveChangesAsync();
                LoadProveedores();
                SelectedProveedor = null; // Clear selection after deletion
            }
        }
    }
}