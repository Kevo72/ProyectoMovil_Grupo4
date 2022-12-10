using static Android.Content.ClipData;

namespace ProyectoMovil_Grupo4.Views;
[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class Categoria : ContentPage
{
    public string ItemId
    {
        set { LoadCategoria(value); }
    }
    string _fileNameCategoria = Path.Combine(FileSystem.AppDataDirectory, "categorias.txt");
    public Categoria()
	{
		InitializeComponent();

        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.categorias.txt";

        LoadCategoria(Path.Combine(appDataPath, randomFileName));
    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        // Save the file.
        if (BindingContext is Models.Categoria categoria)
            File.WriteAllText(categoria.Filename, TextEditorCategoria.Text);

        await Shell.Current.GoToAsync("..");
    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        // Delete the file.
        if (BindingContext is Models.Categoria categoria)
        {
            // Delete the file.
            if (File.Exists(categoria.Filename))
                File.Delete(categoria.Filename);
        }

        await Shell.Current.GoToAsync("..");
    }

    private void LoadCategoria(string fileName)
    {
        Models.Categoria categoriaModel = new Models.Categoria();
        categoriaModel.Filename = fileName;

        if (File.Exists(fileName))
        {
            categoriaModel.Date = File.GetCreationTime(fileName);
            categoriaModel.Text = File.ReadAllText(fileName);
        }

        BindingContext = categoriaModel;
    }
}