using static Android.Content.ClipData;

namespace ProyectoMovil_Grupo4.Views;
[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class Producto : ContentPage
{
    public string ItemId
    {
        set { LoadProducto(value); }
    }
    string _fileNameProductos = Path.Combine(FileSystem.AppDataDirectory, "productos.txt");
    public Producto()
	{
		InitializeComponent();

        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.productos.txt";

        LoadProducto(Path.Combine(appDataPath, randomFileName));
    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        // Save the file.
        if (BindingContext is Models.Producto producto)
            File.WriteAllText(producto.Filename, TextEditorProductos.Text);

        await Shell.Current.GoToAsync("..");
    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        // Delete the file.
        if (BindingContext is Models.Producto producto)
        {
            // Delete the file.
            if (File.Exists(producto.Filename))
                File.Delete(producto.Filename);
        }

        await Shell.Current.GoToAsync("..");
    }

    private void LoadProducto(string fileName)
    {
        Models.Producto productoModel = new Models.Producto();
        productoModel.Filename = fileName;

        if (File.Exists(fileName))
        {
            productoModel.Date = File.GetCreationTime(fileName);
            productoModel.Text = File.ReadAllText(fileName);
        }

        BindingContext = productoModel;
    }
}