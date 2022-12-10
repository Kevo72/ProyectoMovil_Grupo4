namespace ProyectoMovil_Grupo4.Views;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
    }

	private async void irUsuarios(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new AllUsuarios());

    }

	private async void irMarca(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new AllMarcas());
    }

	private async void irCategoria(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new AllCategorias());
    }

	private async void irProducto(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new AllProductos());
    }
}

