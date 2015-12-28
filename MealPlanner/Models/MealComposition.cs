using System;
using System.Collections.Generic;

namespace MealPlanner.Models
{
    public class MealComposition
    {
        public int ID { get; set; }
        public int MealID { get; set; }
        public int? FoodID { get; set; }
        public int? FoodSize { get; set; }
        public int? IngredientID { get; set; }
        public int? IngredientSize { get; set; }

        public virtual Meal Meal { get; set; }
        public virtual Food Food { get; set; }
        public virtual Ingredient Ingredient { get; set; }
    }
}