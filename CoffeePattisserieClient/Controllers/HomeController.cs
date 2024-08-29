using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CoffeePattisserieClient.Models;
using System.Text.Json;

namespace CoffeePattisserieClient.Controllers;

public class HomeController : Controller
{
    public async Task<IActionResult> Index()
    {
        // Anasayfa için kahveleri API'den iste
        var rootCoffees = new Root<List<CoffeeViewModel>>();
        using (var httpClient = new HttpClient())
        {
            using (HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("http://localhost:3534/api/Coffees/homecoffees"))
            {
                if (!httpResponseMessage.IsSuccessStatusCode)
                {
                    return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
                }
                string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                rootCoffees = JsonSerializer.Deserialize<Root<List<CoffeeViewModel>>>(contentResponse);
            }
        }

        // Anasayfa için moctail'leri API'den iste
        var rootMoctails = new Root<List<MoctailViewModel>>();
        using (var httpClient = new HttpClient())
        {
            using (HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("http://localhost:3534/api/Moctails/homemoctails"))
            {
                if (!httpResponseMessage.IsSuccessStatusCode)
                {
                    return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
                }
                string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                rootMoctails = JsonSerializer.Deserialize<Root<List<MoctailViewModel>>>(contentResponse);
            }
        }

        // Anasayfa için pastaları API'den iste
        var rootPattisseries = new Root<List<PattisserieViewModel>>();
        using (var httpClient = new HttpClient())
        {
            using (HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("http://localhost:3534/api/Pattisseries/homepattisseries"))
            {
                if (!httpResponseMessage.IsSuccessStatusCode)
                {
                    return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
                }
                string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                rootPattisseries = JsonSerializer.Deserialize<Root<List<PattisserieViewModel>>>(contentResponse);
            }
        }

        // Bütün ürünleri tek bir listeye ekle
        var products = new List<ProductViewModel>();
        products.AddRange(rootCoffees.Data);
        products.AddRange(rootMoctails.Data);
        products.AddRange(rootPattisseries.Data);

        // Modeli oluştur ve view'a gönder
        var homePageModel = new HomePageModel
        {
            Products = products
        };

        return View(homePageModel);
    }
}
