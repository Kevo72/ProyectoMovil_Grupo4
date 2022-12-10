namespace ProyectoMovil_Grupo4.Views;

public partial class AllProductos : ContentPage
{
	public AllProductos()
	{
		InitializeComponent();
        BindingContext = new Models.AllProductos();
    }

    protected override void OnAppearing()
    {
        ((Models.AllProductos)BindingContext).LoadProductos();
    }

    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(Producto));
    }

    private async void notesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // Get the note model
            var producto = (Models.Producto)e.CurrentSelection[0];

            // Should navigate to "NotePage?ItemId=path\on\device\XYZ.notes.txt"
            await Shell.Current.GoToAsync($"{nameof(Producto)}?{nameof(Producto.ItemId)}={producto.Filename}");

            // Unselect the UI
            productosCollection.SelectedItem = null;
        }
    }
}