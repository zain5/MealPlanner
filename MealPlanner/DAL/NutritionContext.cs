using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using MealPlanner.Models;

namespace MealPlanner.DAL
{
    public class NutritionContext : DbContext
    {
        public NutritionContext() : base("NutritionContext")
        {
        }

        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<FoodIngredient> FoodIngredients { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<MealComposition> MealCompositions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}