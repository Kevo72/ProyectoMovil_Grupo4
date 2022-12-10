using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Google.Crypto.Tink.Subtle;
using static Android.Provider.ContactsContract.CommonDataKinds;

namespace ProyectoMovil_Grupo4.Models
{
    internal class AllMarcas
    {

        public ObservableCollection<Marca> Marcas { get; set; } = new ObservableCollection<Marca>();

        public AllMarcas() =>
        LoadMarcas();

        public void LoadMarcas()
        {
            Marcas.Clear();

            // Get the folder where the notes are stored.
            string appDataPath = FileSystem.AppDataDirectory;

            // Use Linq extensions to load the *.notes.txt files.
            IEnumerable<Marca> marcas = Directory

                                        // Select the file names from the directory
                                        .EnumerateFiles(appDataPath, "*.marca.txt")

                                        // Each file name is used to create a new Note
                                        .Select(filename => new Marca()
                                        {
                                            Filename = filename,
                                            Text = File.ReadAllText(filename),
                                            Date = File.GetCreationTime(filename)
                                        })

                                        // With the final collection of notes, order them by date
                                        .OrderBy(marca => marca.Date);

            // Add each note into the ObservableCollection
            foreach (Marca marca in marcas)
                Marcas.Add(marca);
        }
    }
}
