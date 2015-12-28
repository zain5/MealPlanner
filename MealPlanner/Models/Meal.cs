using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MealPlanner.Models
{
    public class Meal
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Gotta enter a name")]
        [StringLength(100, ErrorMessage = "Name has to be between 1 to 100 characters in length", MinimumLength = 1)]
        public string Name { get; set; }

        public MealCat Category { get; set; }

        [Display(Name = "Date Created")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? DateCreated { get; set; }

        [Display(Name = "Meal Composition")]
        public virtual ICollection<MealComposition> MealCompositions { get; set; }
    }

    public enum MealCat
    {
        Breakfast,
        Lunch,
        Dinner,
        Other
    };
}