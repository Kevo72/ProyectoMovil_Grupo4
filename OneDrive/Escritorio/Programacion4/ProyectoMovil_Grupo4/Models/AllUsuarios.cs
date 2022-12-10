using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Android.Provider.ContactsContract.CommonDataKinds;

namespace ProyectoMovil_Grupo4.Models
{
    internal class AllUsuarios
    {
        public ObservableCollection<Usuarios> Users { get; set; } = new ObservableCollection<Usuarios>();

        public AllUsuarios() =>
            LoadUsuario();

        public void LoadUsuario()
        {
            Users.Clear();

            // Get the folder where the notes are stored.
            string appDataPath = FileSystem.AppDataDirectory;

            // Use Linq extensions to load the *.notes.txt files.
            IEnumerable<Usuarios> usuarios = Directory

                                        // Select the file names from the directory
                                        .EnumerateFiles(appDataPath, "*.usuarios.txt")

                                        // Each file name is used to create a new Note
                                        .Select(filename => new Usuarios()
                                        {
                                            Filename = filename,
                                            Text = File.ReadAllText(filename),
                                            Date = File.GetCreationTime(filename)
                                        })

                                        // With the final collection of notes, order them by date
                                        .OrderBy(usuario => usuario.Date);

            // Add each note into the ObservableCollection
            foreach (Usuarios usuario in usuarios)
                Users.Add(usuario);
        }
    }
}
