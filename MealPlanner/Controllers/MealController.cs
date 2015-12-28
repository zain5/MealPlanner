using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MealPlanner.DAL;
using MealPlanner.Models;
using PagedList;
using MealPlanner.ViewModels;

namespace MealPlanner.Controllers
{
    public class MealController : Controller
    {
        private NutritionContext db = new NutritionContext();

        // GET: Meal
        public ActionResult Index(string sortOrder = null, string searchString = null, int? page = null)
        {
            var meals = from meal in db.Meals
                        select meal;

            if (!string.IsNullOrEmpty(searchString))
            {
                meals = meals.Where(T => T.Name.Contains(searchString));
            }

            ViewBag.SortOrder = sortOrder;
            ViewBag.SearchString = searchString;

            switch (sortOrder)
            {
                case "name_asc":
                    meals = meals.OrderBy(T => T.Name);
                    break;
                case "name_desc":
                    meals = meals.OrderByDescending(T => T.Name);
                    break;
                case "category_asc":
                    meals = meals.OrderBy(T => T.Category);
                    break;
                case "category_desc":
                    meals = meals.OrderByDescending(T => T.Category);
                    break;
                case "dateCreated_asc":
                    meals = meals.OrderBy(T => T.DateCreated);
                    break;
                case "dateCreated_desc":
                    meals = meals.OrderByDescending(T => T.DateCreated);
                    break;
                default:
                    meals = meals.OrderBy(T => T.ID);
                    break;
            }

            return View(meals.ToPagedList((page ?? 1), 3));
        }

        // GET: Meal/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meal meal = db.Meals.Find(id);
            if (meal == null)
            {
                return HttpNotFound();
            }
            return View(meal);
        }

        // GET: Meal/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Meal/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Category,DateCreated")] Meal meal)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Meals.Add(meal);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(meal);
        }

        // GET: Meal/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meal meal = db.Meals.Find(id);
            if (meal == null)
            {
                return HttpNotFound();
            }
            return View(meal);
        }

        // POST: Meal/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var mealToUpdate = db.Meals.Find(id);
            if (mealToUpdate == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (TryUpdateModel(mealToUpdate, "", new string[] { "Name", "Category", "DateCreated" }))
            {
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DataException)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }

            return View(mealToUpdate);
        }

        // GET: Meal/Delete/5
        public ActionResult Delete(int? id, bool saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (saveChangesError)
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }

            Meal meal = db.Meals.Find(id);
            if (meal == null)
            {
                return HttpNotFound();
            }
            return View(meal);
        }

        // POST: Meal/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Meal meal = db.Meals.Find(id);
                db.Meals.Remove(meal);
                db.SaveChanges();
            }
            catch (DataException)
            {
                RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }

            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            IQueryable<MealStat> mealStats = from meal in db.Meals
                                              group meal by meal.Category into mealGroup
                                              select new MealStat
                                              {
                                                  Category = mealGroup.Key,
                                                  Count = mealGroup.Count()
                                              };
            return View(mealStats.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
