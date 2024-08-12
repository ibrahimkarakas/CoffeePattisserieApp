using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeePattisserieClient.Models;
using CoffeePattisserieClient.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CoffeePattisserieClient.Controllers
{
    public class MoctailController : Controller
    {
        public IActionResult Index()
        {
            List<MoctailViewModel> moctails = DataRepository.GetMoctails();
            return View(moctails);
        }

        public IActionResult Update(int id)
        {
            MoctailViewModel updatedMoctail = DataRepository.GetMoctail(id);
            return View(updatedMoctail);
        }

        [HttpPost]
        public IActionResult Update(MoctailViewModel moctailViewModel)
        {
            // Update logic goes here
            return View();
        }
    }
}
