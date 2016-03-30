using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BeHealthy.Controllers
{
    public class HealthyFoodController : Controller
    {
        public static List<Food> Foods = new List<Food>()
        {
            new Food {Id = 1, Name = "Banana", Code = "Ban-12", CaloriesPerKg = 120},
            new Food {Id = 2, Name = "Orange", Code = "ora-45", CaloriesPerKg = 56},
            new Food {Id = 3, Name = "Lemon", Code = "lem-890", CaloriesPerKg = 30},
            new Food {Id=4,Name ="apple",Code="app_123",CaloriesPerKg=10}
        };
        //
        // GET: /HealthyFood/
        public ActionResult Index(string name)
        {
            if(string.IsNullOrEmpty(name))
            return View(Foods);
            else
            {
                return View(Foods.FindAll(c => c.Name.ToLower() == name.ToLower()));
            }
        }

        public ActionResult Delete(int id)
        {
            Foods.RemoveAll(x => x.Id == id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var fod = Foods.First(c => c.Id == id);
            return View(fod);
        }

        [HttpPost]
        public ActionResult Edit(Food food)
        {
            Foods.RemoveAll(c => c.Id == food.Id);
            Foods.Add(food);
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Food food)
        {
            food.Id = Foods.Max(c => c.Id) + 1;
            Foods.Add(food);
            return RedirectToAction("Index");
        }


	}

    public class Food
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Code { get; set; }
        public Double CaloriesPerKg { get; set; }
    }
}