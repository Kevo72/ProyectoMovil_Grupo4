namespace ProyectoMovil_Grupo4.Views;

public partial class AllUsuarios : ContentPage
{
	public AllUsuarios()
	{
		InitializeComponent();

        BindingContext = new Models.AllUsuarios();
    }

    protected override void OnAppearing()
    {
        ((Models.AllUsuarios)BindingContext).LoadUsuario();
    }

    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(Usuarios));
    }

    private async void notesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // Get the note model
            var usuario = (Models.Usuarios)e.CurrentSelection[0];

            // Should navigate to "NotePage?ItemId=path\on\device\XYZ.notes.txt"
            await Shell.Current.GoToAsync($"{nameof(Usuarios)}?{nameof(Usuarios.ItemId)}={usuario.Filename}");

            // Unselect the UI
            usuariosCollection.SelectedItem = null;
        }
    }
}