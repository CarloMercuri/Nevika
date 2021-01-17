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
            var product = await ProductProcessor.RequestProductInfo(ean_code);

            //Product prod = (Product)product;
            Product prod = (Product)product;

            if (prod != null)
            {
                ApplyProduct(prod);
                
                Console.WriteLine(prod.Product_Name);
                Console.WriteLine(prod.Product_Brand);
                Console.WriteLine(prod.Product_Ingredients_Text);
            }
            else
            {
                ChangeName("NULL");
                Console.WriteLine("PRODUCT IS NULL");
            }


            //Console.WriteLine();
        }

        private void ApplyProduct(Product product)
        {
            ChangeName(product.Product_Name);
            ProductIngredientsSlot.Text = product.Product_Ingredients_Text;

            string allergensText = "";

            foreach (Allergen al in App.AllergensList)
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

            ProductFoundAllergensSlot.Text = allergensText;
        }

        private void ChangeName(string name)
        {
            ProductNameSlot.Text = name;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //ProductIconSlot.Source = App.ScannedProduct.IconName;
            ProductNameSlot.Text = "Loading";

            GetProductInfo(Scanned_EAN);

        }
    }
}