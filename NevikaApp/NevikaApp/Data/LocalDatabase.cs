using System;
using System.Collections.Generic;
using System.Text;

namespace NevikaApp.Data
{
    public static class LocalDatabase
    {
        public static string LOCAL_DB_PATH { get; set; }
        public static List<Allergen> AllergensList;

        public static void InitializeLocalDatabase(string db_path)
        {
            LOCAL_DB_PATH = db_path;
            InsertTempAllergens();
            PopulateAllergenList();
        }

        public static void InsertTempAllergens()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(LOCAL_DB_PATH))
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

        public static void DeleteAllergens()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(LOCAL_DB_PATH))
            {
                conn.DropTable<Allergen>();
            }
        }


        public static void PopulateAllergenList()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(LOCAL_DB_PATH))
            {
                conn.CreateTable<Allergen>();
                AllergensList = conn.Table<Allergen>().ToList();
            }
        }
    }
}
