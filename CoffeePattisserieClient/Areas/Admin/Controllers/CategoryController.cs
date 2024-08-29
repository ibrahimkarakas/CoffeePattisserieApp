using CoffeePattisserieClient.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CoffeePattisserieClient.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var rootCategories = new Root<List<CategoryModel>>();
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("http://localhost:3534/api/categories"))
                {
                    if (!httpResponseMessage.IsSuccessStatusCode)
                    {
                        return null; // Bu durumda hata sayfasına yönlendirmek daha iyi olabilir.
                    }
                    string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                    rootCategories = JsonSerializer.Deserialize<Root<List<CategoryModel>>>(contentResponse);
                }
            }
            return View(rootCategories.Data);
        }
    }
}
