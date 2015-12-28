using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MealPlanner.Models;
using System.Data.Entity;

namespace MealPlanner.DAL
{
    public class NutritionInitializer : DropCreateDatabaseIfModelChanges<NutritionContext>
    {
        protected override void Seed(NutritionContext context)
        {
            var ingredients = new List<Ingredient>
            {
                new Ingredient { Name = "White Bread", Size = 100, Category = IngredCat.Grain, Protein = 0, Carb = 20, Sugar = 10, Fat = 0, Calories = 80 },
                new Ingredient { Name = "Chicken", Size = 100, Category = IngredCat.Poultry, Protein = 20, Carb = 0, Sugar = 0, Fat = 3, Calories = 110 },
                new Ingredient { Name = "Beef", Size = 100, Category = IngredCat.Meat, Protein = 20, Carb = 0, Sugar = 0, Fat = 5, Calories = 130 },
                new Ingredient { Name = "Egg", Size = 100, Category = IngredCat.Poultry, Protein = 20, Carb = 0, Sugar = 0, Fat = 4, Calories = 120 },
                new Ingredient { Name = "Orange", Size = 100, Category = IngredCat.Fruit, Protein = 0, Carb = 20, Sugar = 20, Fat = 0, Calories = 80 },
                new Ingredient { Name = "Milk", Size = 100, Category = IngredCat.Dairy, Protein = 10, Carb = 10, Sugar = 20, Fat = 5, Calories = 130 }
            };
            ingredients.ForEach(T => context.Ingredients.Add(T));
            context.SaveChanges();

            var foods = new List<Food>
            {
                new Food { Name = "Chicken Sandwich", Type = FoodType.Sandwich, Category = FoodCat.American },
                new Food { Name = "Burger", Type = FoodType.Burger, Category = FoodCat.FastFood },
                new Food { Name = "Egg Sandwich", Type = FoodType.Sandwich, Category = FoodCat.American },
                new Food { Name = "Orange Juice", Type = FoodType.Beverage, Category = FoodCat.American }
            };
            context.Foods.AddRange(foods);
            context.SaveChanges();

            var foodIngredients = new List<FoodIngredient>
            {
                new FoodIngredient { IngredientID = ingredients.Find(T => T.Name == "Chicken").ID, FoodID = foods.Find(T => T.Name == "Chicken Sandwich").ID, Size = 200 },
                new FoodIngredient { IngredientID = ingredients.Find(T => T.Name == "White Bread").ID, FoodID = foods.Find(T => T.Name == "Chicken Sandwich").ID, Size = 200 },
                new FoodIngredient { IngredientID = ingredients.Find(T => T.Name == "Beef").ID, FoodID = foods.Find(T => T.Name == "Burger").ID, Size = 200 },
                new FoodIngredient { IngredientID = ingredients.Find(T => T.Name == "White Bread").ID, FoodID = foods.Find(T => T.Name == "Burger").ID, Size = 200 },
                new FoodIngredient { IngredientID = ingredients.Find(T => T.Name == "Egg").ID, FoodID = foods.Find(T => T.Name == "Egg Sandwich").ID, Size = 200 },
                new FoodIngredient { IngredientID = ingredients.Find(T => T.Name == "White Bread").ID, FoodID = foods.Find(T => T.Name == "Egg Sandwich").ID, Size = 200 },
                new FoodIngredient { IngredientID = ingredients.Find(T => T.Name == "Orange").ID, FoodID = foods.Find(T => T.Name == "Orange Juice").ID, Size = 200 }
            };
            context.FoodIngredients.AddRange(foodIngredients);
            context.SaveChanges();

            var meals = new List<Meal>
            {
                new Meal { Name = "Egg Breakfast", Category = MealCat.Breakfast, DateCreated = DateTime.Parse("2015-10-20") },
                new Meal { Name = "Chicken Lunch 1", Category = MealCat.Lunch, DateCreated = DateTime.Parse("2015-10-21") },
                new Meal { Name = "Fast Burger Meal 1", Category = MealCat.Dinner, DateCreated = DateTime.Parse("2015-10-22") },
                new Meal { Name = "Chicken Lunch 2", Category = MealCat.Lunch, DateCreated = DateTime.Parse("2015-10-23") },
                new Meal { Name = "Fast Burger Meal 2", Category = MealCat.Dinner, DateCreated = DateTime.Parse("2015-10-24") }
            };
            meals.ForEach(T => context.Meals.Add(T));
            context.SaveChanges();

            var mealCompositions = new List<MealComposition>
            {
                new MealComposition { MealID = meals.Find(T => T.Name == "Egg Breakfast").ID, FoodID = foods.Find(T => T.Name == "Egg Sandwich").ID, FoodSize = 200 },
                new MealComposition { MealID = meals.Find(T => T.Name == "Egg Breakfast").ID, FoodID = foods.Find(T => T.Name == "Orange Juice").ID, FoodSize = 200 },
                new MealComposition { MealID = meals.Find(T => T.Name == "Chicken Lunch 1").ID, FoodID = foods.Find(T => T.Name == "Chicken Sandwich").ID, FoodSize = 200 },
                new MealComposition { MealID = meals.Find(T => T.Name == "Chicken Lunch 1").ID, FoodID = foods.Find(T => T.Name == "Orange Juice").ID, FoodSize = 200 },
                new MealComposition { MealID = meals.Find(T => T.Name == "Fast Burger Meal 1").ID, FoodID = foods.Find(T => T.Name == "Burger").ID, FoodSize = 200 },
                new MealComposition { MealID = meals.Find(T => T.Name == "Fast Burger Meal 1").ID, IngredientID = ingredients.Find(T => T.Name == "Milk").ID, IngredientSize = 100 },
                new MealComposition { MealID = meals.Find(T => T.Name == "Chicken Lunch 2").ID, FoodID = foods.Find(T => T.Name == "Chicken Sandwich").ID, FoodSize = 200 },
                new MealComposition { MealID = meals.Find(T => T.Name == "Chicken Lunch 2").ID, IngredientID = ingredients.Find(T => T.Name == "Milk").ID, IngredientSize = 100 },
                new MealComposition { MealID = meals.Find(T => T.Name == "Fast Burger Meal 2").ID, FoodID = foods.Find(T => T.Name == "Burger").ID, FoodSize = 200 },
                new MealComposition { MealID = meals.Find(T => T.Name == "Fast Burger Meal 2").ID, FoodID = foods.Find(T => T.Name == "Orange Juice").ID, FoodSize = 200 }
            };
            mealCompositions.ForEach(T => context.MealCompositions.Add(T));
            context.SaveChanges();
        }
    }
}