using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeePattisserieClient.Models;
using CoffeePattisserieClient.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CoffeePattisserieClient.Controllers
{
    public class PattisserieController : Controller
    {
        public IActionResult Index()
        {
            List<PattisserieViewModel> pattisseries = DataRepository.GetPattisseries();
            return View(pattisseries);
        }

        public IActionResult Update(int id)
        {
            PattisserieViewModel updatedPattisserie = DataRepository.GetPattisserie(id);
            return View(updatedPattisserie);
        }

        [HttpPost]
        public IActionResult Update(PattisserieViewModel pattisserieViewModel)
        {
            // Update logic goes here
            return View();
        }
    }
}
