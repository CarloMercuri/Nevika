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


            InitializeComponent();
        }

        private async void GetProductInfo(string ean_code)
        {
            Product product = await ProductProcessor.RequestProductInfo(ean_code);

            if (product != null)
            {
                ProductIconSlot.IsVisible = true;
                ProductNameSlot.IsVisible = true;
                LoadingCircle.IsRunning = false;

                ApplyProduct(product);
            }
            else
            {
                ProductIconSlot.IsVisible = true;
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

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ProductIconSlot.IsVisible = false;
            ProductNameSlot.IsVisible = false;

            //ProductIconSlot.Source = App.ScannedProduct.IconName;
            //ProductNameSlot.Text = "Loading";

            GetProductInfo(Scanned_EAN);

        }
    }
}