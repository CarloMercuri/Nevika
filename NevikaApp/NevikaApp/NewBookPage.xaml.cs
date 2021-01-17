using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NevikaApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewBookPage : ContentPage
    {
        public NewBookPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Book book = new Book()
            {
                Name = nameEntry.Text,
                Author = authorEntry.Text
            };

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection((App.DB_PATH)))
            {
                // Creates a new table only if not existing
                conn.CreateTable<Book>();

                // Insert() returns the number of rows inserted. If 0, means it wasn't succesfull
                var numberOfRows = conn.Insert(book);


                if(numberOfRows > 0)
                {
                    DisplayAlert("Success!", "Book inserted successfully", "Great!");
                }
                else
                {
                    DisplayAlert("Error", "Book failed to insert", "Meh");
                }
            }
        }
    }
}