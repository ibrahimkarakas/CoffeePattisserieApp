using CoffeePattisserieClient.Areas.Admin.Data;
using CoffeePattisserieClient.Areas.Admin.Models;
using CoffeePattisserieClient.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;

namespace CoffeePattisserieClient.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}