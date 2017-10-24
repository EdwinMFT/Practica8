using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Practica8
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuDatos : ContentPage
    {
        public ObservableCollection<TESHDatos> Items { set; get; }
        SQLiteConnection database;
        
        public MenuDatos()
        {
            InitializeComponent();
            string db;
            db = DependencyService.Get<ISQLite>().GetLocalFilePath("TESHD.db");
            database = new SQLiteConnection(db);
            database.CreateTable<TESHDatos>();


            Items = new ObservableCollection<TESHDatos>(database.Table<TESHDatos>());
            BindingContext = this;
        }



        
        private void InsertarRegistros_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new RegistrosIUD());
        }

        async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            await Navigation.PushModalAsync(new SelectPage(e.SelectedItem as TESHDatos));
            

        }
    }


}