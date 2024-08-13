using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CoffeePattisserieClient.Models;
using CoffeePattisserieClient.Repository;

namespace CoffeePattisserieClient.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var categoryList = DataRepository.GetCategories();
        return View(categoryList);
    }
}
