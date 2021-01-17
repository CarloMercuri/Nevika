using NevikaApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NevikaApp.Pages
{
    public partial class UserOptionsPage : ContentPage
    {
        public UserOptionsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();



            allergensListView.ItemsSource = App.AllergensList;

        }

        private void OnCheckedChanged(object sender, EventArgs e)
        {
            var checkbox = (CheckBox)sender;
            var allergen = checkbox.BindingContext as Allergen;

            if(allergen != null)
            {
                int index = App.AllergensList.FindIndex(al => al.DanishName == allergen.DanishName);
                Console.WriteLine($"Index found is: {index}");
                App.AllergensList[index].Selected = checkbox.IsChecked;

                using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
                {
                    //Console.WriteLine($"Before: {conn.Get<Allergen>(App.AllergensList[index].Id).Selected}, should change to: {App.AllergensList[index].Selected}");
                    conn.Update(App.AllergensList[index]);
                    //Allergen al = conn.Get<Allergen>(index);
                    //Console.WriteLine($"After: {conn.Get<Allergen>(App.AllergensList[index].Id).Selected}");

                }
                    //Console.WriteLine($"Allergen clicked: {allergen.DanishName}. Is selected now is: {checkbox.IsChecked}");

            }
        }

    }
}
