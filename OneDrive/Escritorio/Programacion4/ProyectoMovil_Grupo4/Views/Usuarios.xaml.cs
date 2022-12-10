using static Android.Content.ClipData;

namespace ProyectoMovil_Grupo4.Views;
[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class Usuarios : ContentPage
{
    string _fileNameUsuarios = Path.Combine(FileSystem.AppDataDirectory, "usuarios.txt");
    public string ItemId
    {
        set { LoadUsuario(value); }
    }
    public Usuarios()
	{

		InitializeComponent();

        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.usuarios.txt";

        LoadUsuario(Path.Combine(appDataPath, randomFileName));
    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        // Save the file.
        if (BindingContext is Models.Usuarios usuario)
            File.WriteAllText(usuario.Filename, TextEditorUsuarios.Text);

        await Shell.Current.GoToAsync("..");
    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        // Delete the file.
        if (BindingContext is Models.Usuarios usuario)
        {
            // Delete the file.
            if (File.Exists(usuario.Filename))
                File.Delete(usuario.Filename);
        }

        await Shell.Current.GoToAsync("..");
    }

    private void LoadUsuario(string fileName)
    {
        Models.Usuarios usuarioModel = new Models.Usuarios();
        usuarioModel.Filename = fileName;

        if (File.Exists(fileName))
        {
            usuarioModel.Date = File.GetCreationTime(fileName);
            usuarioModel.Text = File.ReadAllText(fileName);
        }

        BindingContext = usuarioModel;
    }
}