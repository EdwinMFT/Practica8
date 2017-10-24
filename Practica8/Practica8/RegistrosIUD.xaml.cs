using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Practica8
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrosIUD : ContentPage
    {
        SQLiteConnection database;
        string datoPiker,datopikersem;
        public RegistrosIUD()
        {
            InitializeComponent();
            string db;
            db = DependencyService.Get<ISQLite>().GetLocalFilePath("TESHD.db");
            database = new SQLiteConnection(db);
            database.CreateTable<TESHDatos>();
        }

        private void Insertar_Clicked(object sender, EventArgs e)
        {
            int t = 10;


            try
            {

                var datos = new TESHDatos
                {
                    Matricula = Convert.ToInt64(Entry_ID.Text),

                    Nombre = Entry_Name.Text,
                    Apellidos = Entry_Ap.Text,
                    Direccion = Entry_Dir.Text,
                    Telefono = Convert.ToInt64(Entry_Tel.Text),
                    //Carrera=Entry_Car.Text,
                    Carrera = datoPiker,
                    //Semestre = Entry_Sem.Text,
                    Semestre = datopikersem,
                    Correo = Entry_Cor.Text,
                    Github = Entry_Git.Text
                };
                


                if (Entry_ID.Text == null)
                {
                    DisplayAlert("", "Ingresar Matricula", "ok");
                }
                else if (Entry_Name.Text == null)
                {
                    DisplayAlert("", "Ingrese un Nombre", "ok");
                }
                else if (Entry_Ap.Text == null)
                {
                    DisplayAlert("", "Ingresar Apellidos", "ok");
                }
                else if (Entry_Dir.Text == null)
                {
                    DisplayAlert("", "Ingresar una Direccion", "ok");
                }
                else if (Entry_Tel.Text == null)
                {
                    DisplayAlert("", "Ingresar Telefono", "ok");
                }
                else if (datoPiker == null)
                {
                    DisplayAlert("", "Ingresa una Carrera", "ok");
                }else if (datopikersem == null)
                {
                    DisplayAlert("", "Ingresar un Semestre", "ok");
                }else if (Entry_Cor.Text == null)
                {
                    DisplayAlert("", "Ingresar un Correo", "ok");
                }else if (Entry_Git.Text == null)
                {
                    DisplayAlert("", "Ingresar una cuenta de GitHub", "ok");
                }
                else if (Entry_Tel.Text.Length != t)
                {
                    DisplayAlert("", "El Numero Telefonico debe contener 10 Digitos", "ok");
                }
                else { 
                 
                
                    try
                    {
                        database.Insert(datos);
                        DisplayAlert("", "Registro Agregado", "ok");
                        Navigation.PushModalAsync(new MenuDatos());

                    }
                    catch (SQLite.SQLiteException ex1)
                    {
                        DisplayAlert("", "Error Matricula Existente SQLITE ", "ok1");                        
                    }

                }
            }
            catch (System.FormatException ex2)
            {
                DisplayAlert("", "Ingresar Unicamente Numeros Valide Matricula u Telefono", "ok2");
            }
        
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                datoPiker = (string)picker.ItemsSource[selectedIndex];
            }
        }

        private void Cancelar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MenuDatos());
        }

        private void PickerSem_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                datopikersem = (string)picker.ItemsSource[selectedIndex];
            }
        }
    }
}