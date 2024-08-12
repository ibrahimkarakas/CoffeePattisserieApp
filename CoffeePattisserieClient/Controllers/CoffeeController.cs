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
        List<CoffeeViewModel> coffees = DataRepository.GetCoffees();
        return View(coffees);
    }
    public IActionResult Update(int id)
    {
        CoffeeViewModel updatedCoffee = DataRepository.GetCoffee(id);
        return View(updatedCoffee);
    }
    [HttpPost]
    public IActionResult Update(CoffeeViewModel coffeeViewModel){
        return View();
    }
}
}