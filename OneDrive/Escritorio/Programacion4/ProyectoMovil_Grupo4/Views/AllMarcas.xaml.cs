namespace ProyectoMovil_Grupo4.Views;

public partial class AllMarcas : ContentPage
{
	public AllMarcas()
	{
		InitializeComponent();

        BindingContext = new Models.AllMarcas();
    }

    protected override void OnAppearing()
    {
        ((Models.AllMarcas)BindingContext).LoadMarcas();
    }

    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(Marca));
    }

    private async void notesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // Get the marca model
            var marca = (Models.Marca)e.CurrentSelection[0];

            // Should navigate to "NotePage?ItemId=path\on\device\XYZ.notes.txt"
            await Shell.Current.GoToAsync($"{nameof(Marca)}?{nameof(Marca.ItemId)}={marca.Filename}");

            // Unselect the UI
            marcasCollection.SelectedItem = null;
        }
    }
}