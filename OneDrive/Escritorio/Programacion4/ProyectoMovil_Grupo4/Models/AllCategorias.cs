using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Android.Provider.ContactsContract.CommonDataKinds;

namespace ProyectoMovil_Grupo4.Models
{
    internal class AllCategorias
    {
        public ObservableCollection<Categoria> Categories { get; set; } = new ObservableCollection<Categoria>();

        public AllCategorias() =>
            LoadCategorias();

        public void LoadCategorias()
        {
            Categories.Clear();

            // Get the folder where the notes are stored.
            string appDataPath = FileSystem.AppDataDirectory;

            // Use Linq extensions to load the *.notes.txt files.
            IEnumerable<Categoria> categorias = Directory

                                        // Select the file names from the directory
                                        .EnumerateFiles(appDataPath, "*.categorias.txt")

                                        // Each file name is used to create a new Note
                                        .Select(filename => new Categoria()
                                        {
                                            Filename = filename,
                                            Text = File.ReadAllText(filename),
                                            Date = File.GetCreationTime(filename)
                                        })

                                        // With the final collection of notes, order them by date
                                        .OrderBy(categoria => categoria.Date);

            // Add each note into the ObservableCollection
            foreach (Categoria categoria in categorias)
                Categories.Add(categoria);
        }
    }
}
