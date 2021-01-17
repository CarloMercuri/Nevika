using NevikaApp.API;
using NevikaApp.Data;
using NevikaApp.Pages;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NevikaApp
{
    public partial class App : Application
    {
        public static string DB_PATH = string.Empty;
        public static List<Allergen> AllergensList;
        public static Product ScannedProduct;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new SplashPage());
        }

        public App(string _db_path)
        {
            InitializeComponent();
            ApiHelper.InitializeClient();

            DB_PATH = _db_path;

            //DeleteAllergens();
            InsertTempAllergens();
            PopulateAllergenList();

            // Products
            //DeleteProducts();
            //InsertProductsList();

            MainPage = new NavigationPage(new SplashPage());
            
        }

        private void InsertProductsList()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DB_PATH))
            {
                conn.CreateTable<Product>();

                var rowsNumber = conn.InsertAll(GenerateTempProducts());
            }
        }

        private List<Product> GenerateTempProducts()
        {
            List<Product> tempList = new List<Product>();

            tempList.Add(new Product()
            {
                Product_Name = "LetMælk",
                Product_EAN_Code = "5700426101217",
                Product_Brand = "Arla",
                IconName = "icon_1.png",
                IngredientsList = new List<string>()
                {
                    "Mælk"
                },
            });

            tempList.Add(new Product()
            {
                Product_Name = "Choko-Crisps",
                Product_EAN_Code = "5712871869291",
                Product_Brand = "Budget",
                IconName = "icon_3.png",
                IngredientsList = new List<string>()
                {
                    "Havregryn",
                    "Sukker",
                    "Rapsolie",
                    "Chokolade",
                    "E322",
                    "Rismel",
                    "Hvedemel",
                    "Glukosesirup",
                    "Honning",
                    "Bygmaltmel",
                    "Kakao",
                    "Vaniljearoma",
                    "Havsalt",
                    "Solsikkeolie"
                },
            });

            tempList.Add(new Product()
            {
                Product_Name = "Panang Red Curry",
                Product_EAN_Code = "7340191101395",
                Product_Brand = "Coop",
                IconName = "icon_2.png",
                IngredientsList = new List<string>()
                {
                    "Rå rørsukker",
                    "Paprikapulver",
                    "Salt",
                    "Hvidløg",
                    "Løgpulver",
                    "Galangarod",
                    "Ingefær",
                    "Chili",
                    "Maltodextrin",
                    "Citronsaft",
                    "Fiskepulver",
                    "E551",
                    "Jordnødder",
                    "Selleri",
                    "Sennap"
                },
            });

            return tempList;
        }

        
        public void InsertTempAllergens()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DB_PATH))
            {
                conn.CreateTable<Allergen>();

                //var numberOfRows = conn.Insert(book);
                List<Allergen> tempList = new List<Allergen>();

                /*
                tempList.Add(new Allergen()
                {
                    DanishName = "Gluten",
                    EnglishName = "Gluten"
                });
                */

                tempList.Add(new Allergen()
                {
                    DanishName = "Soja",
                    EnglishName = "Soy"
                });

                tempList.Add(new Allergen()
                {
                    DanishName = "Nødder",
                    EnglishName = "Nuts"
                });

                tempList.Add(new Allergen()
                {
                    DanishName = "Jordnødder",
                    EnglishName = "Peanut"
                });


                tempList.Add(new Allergen()
                {
                    DanishName = "Sesam",
                    EnglishName = "Sesam"
                });

                tempList.Add(new Allergen()
                {
                    DanishName = "Mælk",
                    EnglishName = "Milk"
                });

                tempList.Add(new Allergen()
                {
                    DanishName = "Æg",
                    EnglishName = "Eggs"
                });

                tempList.Add(new Allergen()
                {
                    DanishName = "Fisk",
                    EnglishName = "Fish"
                });

                tempList.Add(new Allergen()
                {
                    DanishName = "Krebsdyr",
                    EnglishName = "Shellfish"
                });

                tempList.Add(new Allergen()
                {
                    DanishName = "Selleri",
                    EnglishName = "Celery"
                });

                tempList.Add(new Allergen()
                {
                    DanishName = "Svovldioxid",
                    EnglishName = "Sulfur Dioxide"
                });

                tempList.Add(new Allergen()
                {
                    DanishName = "Laktose",
                    EnglishName = "Lactose"
                });

                tempList.Add(new Allergen()
                {
                    DanishName = "Sukker",
                    EnglishName = "Sugar"
                });

                tempList.Add(new Allergen()
                {
                    DanishName = "Smør",
                    EnglishName = "Butter"
                });

                tempList.Add(new Allergen()
                {
                    DanishName = "Boghvede",
                    EnglishName = "Buchwheat"
                });

                tempList.Add(new Allergen()
                {
                    DanishName = "Frugt",
                    EnglishName = "Fruit"
                });

                tempList.Add(new Allergen()
                {
                    DanishName = "Hvidløg",
                    EnglishName = "Garlic"
                });

                tempList.Add(new Allergen()
                {
                    DanishName = "Chili",
                    EnglishName = "Chili"
                });

                tempList.Add(new Allergen()
                {
                    DanishName = "Havre",
                    EnglishName = "Oats"
                });

                tempList.Add(new Allergen()
                {
                    DanishName = "Majs",
                    EnglishName = "Corn"
                });

                tempList.Add(new Allergen()
                {
                    DanishName = "Fjerkræ",
                    EnglishName = "Poultry"
                });



                var rowsNumber = conn.InsertAll(tempList);
            }
        }
        
        public void DeleteProducts()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DB_PATH))
            {
                conn.DropTable<Product>();
            }
        }
        public void DeleteAllergens()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DB_PATH))
            {
                conn.DropTable<Allergen>();
            }
        }


        public void PopulateAllergenList()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DB_PATH))
            {
                conn.CreateTable<Allergen>();
                AllergensList = conn.Table<Allergen>().ToList();
            }
        }
        

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
