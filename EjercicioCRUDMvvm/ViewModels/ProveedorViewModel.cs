using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using EjercicioCRUDMvvm.Data;
using EjercicioCRUDMvvm.Models;
using Microsoft.Maui.Controls;

namespace EjercicioCRUDMvvm.ViewModels
{
    public class ProveedorViewModel : INotifyPropertyChanged
    {
        private readonly AppDbContext _dbContext;

#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de agregar el modificador "required" o declararlo como un valor que acepta valores NULL.
        public ProveedorViewModel()
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de agregar el modificador "required" o declararlo como un valor que acepta valores NULL.
        {
            _dbContext = new AppDbContext();
            LoadProveedores();
        }

        private ObservableCollection<Proveedor> _proveedores;
        public ObservableCollection<Proveedor> Proveedores
        {
            get => _proveedores;
            set
            {
                _proveedores = value;
                OnPropertyChanged();
            }
        }

        private Proveedor _selectedProveedor;
        public Proveedor SelectedProveedor
        {
            get => _selectedProveedor;
            set
            {
                _selectedProveedor = value;
                OnPropertyChanged();
            }
        }

        public Command SaveCommand => new Command(async () => await SaveProveedor(Get_dbContext()));
        public Command DeleteCommand => new Command(async () => await DeleteProveedor());

        private AppDbContext Get_dbContext()
        {
            return _dbContext;
        }

        private async Task SaveProveedor(AppDbContext _dbContext)
        {
            if (SelectedProveedor != null && ValidateProveedor(SelectedProveedor))
            {
                if (SelectedProveedor.Id == 0)



                    object value = _dbContext.Proveedores.Add(SelectedProveedor);
                else
                    _dbContext.Proveedores.Update(SelectedProveedor);

                await _dbContext.SaveChangesAsync();
                LoadProveedores();
            }
        }

        private async Task DeleteProveedor()
        {
            if (SelectedProveedor != null)
            {
                _dbContext.Proveedores.Remove(SelectedProveedor);
                await _dbContext.SaveChangesAsync();
                LoadProveedores();
            }
        }

        private void LoadProveedores()
        {
            Proveedores = new ObservableCollection<Proveedor>(_dbContext.Proveedores.ToList());
        }

        private bool ValidateProveedor(Proveedor proveedor)
        {
            // Simplified validation; you can use more advanced validation
            return !string.IsNullOrWhiteSpace(proveedor.Nombre) &&
                   !string.IsNullOrWhiteSpace(proveedor.Direccion) &&
                   !string.IsNullOrWhiteSpace(proveedor.Ciudad) &&
                   !string.IsNullOrWhiteSpace(proveedor.Telefono) &&
                   !string.IsNullOrWhiteSpace(proveedor.Email);
        }

#pragma warning disable CS8612 // La nulabilidad de los tipos de referencia del tipo no coincide con el miembro implementado de forma implícita
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore CS8612 // La nulabilidad de los tipos de referencia del tipo no coincide con el miembro implementado de forma implícita

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
