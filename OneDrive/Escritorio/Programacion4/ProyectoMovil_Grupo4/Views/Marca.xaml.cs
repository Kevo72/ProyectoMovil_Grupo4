using static Android.Content.ClipData;

namespace ProyectoMovil_Grupo4.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class Marca : ContentPage
{
    public string ItemId
    {
        set { LoadMarca(value); }
    }
    string _fileNameMarca = Path.Combine(FileSystem.AppDataDirectory, "marca.txt");
    public Marca()
	{
		InitializeComponent();

        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.marca.txt";

        LoadMarca(Path.Combine(appDataPath, randomFileName));
    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Marca marca)
            File.WriteAllText(marca.Filename, TextEditorMarca.Text);

        await Shell.Current.GoToAsync("..");
    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        // Delete the file.
        if (BindingContext is Models.Marca marca)
        {
            // Delete the file.
            if (File.Exists(marca.Filename))
                File.Delete(marca.Filename);
        }

        await Shell.Current.GoToAsync("..");
    }

    private void LoadMarca(string fileName)
    {
        Models.Marca marcaModel = new Models.Marca();
        marcaModel.Filename = fileName;

        if (File.Exists(fileName))
        {
            marcaModel.Date = File.GetCreationTime(fileName);
            marcaModel.Text = File.ReadAllText(fileName);
        }

        BindingContext = marcaModel;
    }
}