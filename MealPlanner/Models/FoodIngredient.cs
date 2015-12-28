using System;
using System.Collections.Generic;

namespace MealPlanner.Models
{
    public class FoodIngredient
    {
        public int ID { get; set; }
        public int IngredientID { get; set; }
        public int FoodID { get; set; }
        public int Size { get; set; }

        public virtual Ingredient Ingredient { get; set; }
        public virtual Food Food { get; set; }
    }
}