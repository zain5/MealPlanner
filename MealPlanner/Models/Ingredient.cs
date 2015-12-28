using System;
using System.Collections.Generic;

namespace MealPlanner.Models
{
    public class Ingredient
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public IngredCat? Category { get; set; }
        public int Protein { get; set; }
        public int Fat { get; set; }
        public int Carb { get; set; }
        public int Sugar { get; set; }
        public int Calories { get; set; }

        public virtual ICollection<FoodIngredient> FoodIngredients { get; set; }
    }

    public enum IngredCat
    {
        Meat,
        Poultry,
        Seafood,
        Vegetable,
        Fruit,
        Starch,
        Dairy,
        Seed,
        Grain,
        Oil,
        Other
    };
}