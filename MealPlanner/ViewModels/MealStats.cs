using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MealPlanner.Models;

namespace MealPlanner.ViewModels
{
    public class MealStat
    {
        public MealCat Category { get; set; }
        public int Count { get; set; }
    }
}