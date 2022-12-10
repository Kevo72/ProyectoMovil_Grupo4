namespace ProyectoMovil_Grupo4.Views;

public partial class AllCategorias : ContentPage
{
	public AllCategorias()
	{
		InitializeComponent();
        BindingContext = new Models.AllCategorias();
    }

    protected override void OnAppearing()
    {
        ((Models.AllCategorias)BindingContext).LoadCategorias();
    }

    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(Categoria));
    }

    private async void notesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // Get the note model
            var categoria = (Models.Categoria)e.CurrentSelection[0];

            // Should navigate to "NotePage?ItemId=path\on\device\XYZ.notes.txt"
            await Shell.Current.GoToAsync($"{nameof(Categoria)}?{nameof(Categoria.ItemId)}={categoria.Filename}");

            // Unselect the UI
            categoriasCollection.SelectedItem = null;
        }
    }
}