using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CoffeePattisserieClient.Models;
using CoffeePattisserieClient.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CoffeePattisserieClient.Controllers
{
    public class CoffeeController : Controller
    {
        public IActionResult Index()
        {
            var coffeeList = DataRepository.GetCoffees(); // Burada veriler DataRepository'den alınıyor
            return View(coffeeList);
        }

        // GET: Coffee/Update/{id}
        public IActionResult Update(int id)
        {
            var coffee = DataRepository.GetCoffee(id);
            if (coffee == null)
            {
                return NotFound();
            }
            return View(coffee);
        }

        // POST: Coffee/Update
        [HttpPost]
        public IActionResult Update(CoffeeViewModel coffeeViewModel)
        {
            if (ModelState.IsValid)
            {
                // Mevcut kahve verisini güncelle
                var coffee = DataRepository.GetCoffee(coffeeViewModel.Id);
                if (coffee != null)
                {
                    // Güncellemeyi yap
                    coffee.Name = coffeeViewModel.Name;
                    coffee.Price = coffeeViewModel.Price;
                    coffee.StockQuantity = coffeeViewModel.StockQuantity;
                    coffee.OriginCountry = coffeeViewModel.OriginCountry;
                    coffee.RoastLevel = coffeeViewModel.RoastLevel;
                    coffee.CaffeineContent = coffeeViewModel.CaffeineContent;
                    coffee.FlavorNotes = coffeeViewModel.FlavorNotes;
                    coffee.ImageUrl = coffeeViewModel.ImageUrl;

                    // Güncellenmiş veriyi sakla
                }
                return RedirectToAction("Index");
            }
            return View(coffeeViewModel);
        }
    }
}
