using EjercicioCRUDMvvm.ViewModels;

public partial class App : Application
{
    public App()
    {
        throw new NotImplementedException();
#pragma warning disable CS0162 // Se detectó código inaccesible
        MainPage = new NavigationPage(new ProveedorPage());
#pragma warning restore CS0162 // Se detectó código inaccesible
    }
}
