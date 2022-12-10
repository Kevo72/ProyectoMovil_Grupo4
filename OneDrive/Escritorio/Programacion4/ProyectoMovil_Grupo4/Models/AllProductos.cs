using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Android.Provider.ContactsContract.CommonDataKinds;

namespace ProyectoMovil_Grupo4.Models
{
    internal class AllProductos
    {
        public ObservableCollection<Producto> Products { get; set; } = new ObservableCollection<Producto>();

        public AllProductos() =>
            LoadProductos();

        public void LoadProductos()
        {
            Products.Clear();

            // Get the folder where the notes are stored.
            string appDataPath = FileSystem.AppDataDirectory;

            // Use Linq extensions to load the *.notes.txt files.
            IEnumerable<Producto> productos = Directory

                                        // Select the file names from the directory
                                        .EnumerateFiles(appDataPath, "*.productos.txt")

                                        // Each file name is used to create a new Note
                                        .Select(filename => new Producto()
                                        {
                                            Filename = filename,
                                            Text = File.ReadAllText(filename),
                                            Date = File.GetCreationTime(filename)
                                        })

                                        // With the final collection of notes, order them by date
                                        .OrderBy(producto => producto.Date);

            // Add each note into the ObservableCollection
            foreach (Producto producto in productos)
                Products.Add(producto);
        }
    }
}
