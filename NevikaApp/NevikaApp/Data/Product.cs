using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace NevikaApp.Data
{
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Product_Name { get; set; }
        public string Product_Brand { get; set; }
        public string Product_Ingredients_Text { get; set; }
        public string IconName { get; set; }
        public string Product_EAN_Code { get; set; }

        public List<string> IngredientsList;
    }
}
