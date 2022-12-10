namespace ProyectoMovil_Grupo4.Views;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
    }

	private async void irUsuarios(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new Usuarios());

    }

	private async void irMarca(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new Marca());
    }

	private async void irCategoria(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new Categoria());
    }

	private async void irProducto(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new Producto());
    }
}

