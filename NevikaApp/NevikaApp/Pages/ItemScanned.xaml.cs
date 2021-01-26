using NevikaApp.API;
using NevikaApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NevikaApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemScanned : ContentPage
    {
        
        private string Scanned_EAN { get; set; }
        public string sourceImage;
        public Product product;

        public ItemScanned()
        {
            InitializeComponent();
        }

        public ItemScanned(string ean_code)
        {
            Scanned_EAN = ean_code;

            // Next in line is OnAppearing()
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // First thing is hide these controls, so that we are only showing
            // the loading icon
            ProductIconSlot.IsVisible = false;
            ProductNameSlot.IsVisible = false;

            // Let's try and find the product
            GetProductInfo(Scanned_EAN);

        }

        /// <summary>
        /// Queries the API on nevika.taotek.dk for a product
        /// </summary>
        /// <param name="ean_code"></param>
        private async void GetProductInfo(string ean_code)
        {
            // Try and get a product
            Product product = await ProductProcessor.RequestProductInfo(ean_code);

            if (product != null)
            {
                // If the product is found, stop the loading icon and activate the other slots.
                // All of this is temporary

                ProductIconSlot.IsVisible = true;
                ProductNameSlot.IsVisible = true;
                LoadingCircle.IsRunning = false;

                // ONLY FOR TESTING, need to implement the icons in the database first
                switch(ean_code)
                {
                    case "8710398169280":
                        ProductIconSlot.Source = "Cruesli.png";
                        break;

                    case "5000159461122":
                        ProductIconSlot.Source = "snickers.jpg";
                        break;

                    case "25065244":
                        ProductIconSlot.Source = "Milk.png";
                        break;

                    default:
                        ProductIconSlot.IsVisible = false;
                        break;
                }

                // If successful, apply the product information on the page
                ApplyProduct(product);
            }
            else
            {
                // Else nope.
                // All of the frontend for this page is very temporary
                ProductNameSlot.IsVisible = true;
                LoadingCircle.IsRunning = false;

                ChangeName("NULL");
            }
        }

        private void ApplyProduct(Product product)
        {
            ChangeName(product.Product_Name);

            Console.WriteLine(product.Product_Ingredients_Text);

            if(product.Product_Ingredients_Text == "NULL" || product.Product_Ingredients_Text.Length <= 0)
            {
                ProductIngredientsSlot.Text = "";
                Label_Ingredients.Text = "Ingen ingredienser fundet";
            }
            else
            {
                Label_Ingredients.Text = "Ingredienser:";
                ProductIngredientsSlot.Text = product.Product_Ingredients_Text;
                
            }

            string allergensText = "";

            // Again temporary until we decide exactly how to do this. For now it just looks for a match in the 
            // ingredients text.
            foreach (Allergen al in LocalDatabase.AllergensList)
            {
                if(product.Product_Ingredients_Text.ToLower().Contains(al.DanishName.ToLower()) && al.Selected)
                {
                    if(allergensText != "")
                    {
                        allergensText += ", ";
                    }

                    allergensText += al.DanishName;
                }
            }

            // If it found something, the string is gonna be > 0
            if(allergensText.Length > 0)
            {
                Label_Allergens.Text = "Allergener i varen:";
                ProductFoundAllergensSlot.Text = allergensText;
            }
            else
            {
                Label_Allergens.Text = "Ingen allergener fundet";
            }

            
        }

        private void ChangeName(string name)
        {
            ProductNameSlot.Text = name;
        }

       
    }
}