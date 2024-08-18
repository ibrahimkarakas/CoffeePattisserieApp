using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CoffeePattisserieClient.Models;
using CoffeePattisserieClient.Repository;

namespace CoffeePattisserieClient.Controllers;

public class HomeController : Controller
{
  public IActionResult Index()
{
    var coffees = DataRepository.GetCoffees();
    var moctails = DataRepository.GetMoctails();
    var pattisseries = DataRepository.GetPattisseries();

    var model = new Tuple<List<CoffeeViewModel>, List<MoctailViewModel>, List<PattisserieViewModel>>(coffees, moctails, pattisseries);
    return View(model);
}


}

