namespace ProyectoMovil_Grupo4;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(Views.Marca), typeof(Views.Marca));
        Routing.RegisterRoute(nameof(Views.Usuarios), typeof(Views.Usuarios));
        Routing.RegisterRoute(nameof(Views.MainPage), typeof(Views.MainPage));
        Routing.RegisterRoute(nameof(Views.Categoria), typeof(Views.Categoria));
        Routing.RegisterRoute(nameof(Views.Producto), typeof(Views.Producto));
    }
}
