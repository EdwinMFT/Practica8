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
    public partial class SelectPage : ContentPage
    {
        SQLiteConnection database;
        string datoPiker, datopikersem;
        public SelectPage(object selectedItem)
        {
            var dato = selectedItem as TESHDatos;
            BindingContext = dato;
            InitializeComponent();
            string db;
            db = DependencyService.Get<ISQLite>().GetLocalFilePath("TESHD.db");
            database = new SQLiteConnection(db);
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

        private void PickerSem_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                datopikersem = (string)picker.ItemsSource[selectedIndex];
            }
        }

        private void Actualizar_Clicked(object sender, EventArgs e)
        {
            //    var datos = new TESHDatos
            //    {
            //        Matricula = Convert.ToInt64(Entry_ID.Text),
            //        Nombre = Entry_Name.Text,
            //        Apellidos = Entry_Ap.Text,
            //        Direccion = Entry_Dir.Text,
            //        Telefono = Entry_Tel.Text,
            //        Carrera = datoPiker,
            //        Semestre = datopikersem,
            //        Correo = Entry_Cor.Text,
            //        Github = Entry_Git.Text
            //    };
            //    database.Update(datos);
            //    Navigation.PushModalAsync(new MenuDatos());
            //    DisplayAlert("", "Regsitro Actualizado", "OK");
            //}
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
                if (Entry_ID.Text == "")
                {
                    DisplayAlert("", "Ingresar Matricula", "ok");
                }
                else if (Entry_Name.Text == "")
                {
                    DisplayAlert("", "Ingrese un Nombre", "ok");
                }
                else if (Entry_Ap.Text == "")
                {
                    DisplayAlert("", "Ingresar Apellidos", "ok");
                }
                else if (Entry_Dir.Text == "")
                {
                    DisplayAlert("", "Ingresar una Direccion", "ok");
                }
                else if (Entry_Tel.Text == "")
                {
                    DisplayAlert("", "Ingresar Telefono", "ok");
                }
                else if (datoPiker == "")
                {
                    DisplayAlert("", "Ingresa una Carrera", "ok");
                }
                else if (datopikersem == "")
                {
                    DisplayAlert("", "Ingresar un Semestre", "ok");
                }
                else if (Entry_Cor.Text == "")
                {
                    DisplayAlert("", "Ingresar un Correo", "ok");
                }
                else if (Entry_Git.Text == "")
                {
                    DisplayAlert("", "Ingresar una cuenta de GitHub", "ok");
                }
                else if (Entry_Tel.Text.Length != t)
                {
                    DisplayAlert("", "El Numero Telefonico debe contener 10 Digitos", "ok");
                }
                else
                {
                    

                        try
                        {
                            database.Update(datos);
                            DisplayAlert("", "Registro Actualizado", "ok");
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

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MenuDatos());
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            var datos = new TESHDatos
            {
                Matricula = Convert.ToInt64(Entry_ID.Text),
                Nombre = Entry_Name.Text,
                Apellidos = Entry_Ap.Text,
                Direccion = Entry_Dir.Text,
                Telefono = Convert.ToInt64(Entry_Tel.Text),
                Carrera = datoPiker,
                Semestre = datopikersem,
                Correo = Entry_Cor.Text,
                Github = Entry_Git.Text
            };
            database.Delete(datos);
            Navigation.PushModalAsync(new MenuDatos());
            DisplayAlert("", "Regsitro Eliminado", "OK");
        }

        //private void Insertar_Clicked(object sender, EventArgs e)
        //{
        //    //Navigation.PushAsync(new BasedeDatos());

        //    try
        //    {

        //        var datos = new TESHDatos
        //        {
        //            Matricula = Convert.ToInt64(Entry_ID.Text),

        //            Nombre = Entry_Name.Text,
        //            Apellidos = Entry_Ap.Text,
        //            Direccion = Entry_Dir.Text,
        //            Telefono = Entry_Tel.Text,
        //            //Carrera=Entry_Car.Text,
        //            Carrera = datoPiker,
        //            Semestre = Entry_Sem.Text,
        //            Correo = Entry_Cor.Text,
        //            Github = Entry_Git.Text
        //        };


        //        try
        //        {
        //            database.Insert(datos);
        //            DisplayAlert("", "Regsitro Agregado", "OK");
        //            Navigation.PushAsync(new MenuDatos());
        //            //
        //        }
        //        catch (SQLite.SQLiteException ex1)
        //        {
        //            DisplayAlert("", "Error Matricula Existente SQLITE ", "ok1");
        //        }
        //    }
        //    catch (System.FormatException ex2)
        //    {
        //        DisplayAlert("", "Ingresar Unicamente Numeros", "ok2");
        //    }
        //    }
        }
}