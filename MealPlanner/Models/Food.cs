using System;
using System.Collections.Generic;

namespace MealPlanner.Models
{
    public class Food
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public FoodCat? Category { get; set; }
        public FoodType? Type { get; set; }

        public virtual ICollection<FoodIngredient> FoodIngredients { get; set; }
    }

    public enum FoodCat
    {
        FastFood,
        American,
        Mexican,
        Chinese,
        Indian,
        Mediterranean,
        Cajun,
        Latin,
        Other
    };

    public enum FoodType
    {
        Burger,
        Sandwich,
        StirFry,
        Pasta,
        Pastry,
        Dessert,
        Beverage
    };
}