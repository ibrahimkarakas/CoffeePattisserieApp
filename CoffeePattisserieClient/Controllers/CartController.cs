using CoffeePattisserieClient.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CoffeePattisserieClient.Controllers
{
    public class CartController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var rootCart = new Root<CartViewModel>();
            using (var httpClient = new HttpClient())
            {
                // Burada cartId'yi dinamik olarak alabilir veya sabit bir ID kullanabilirsiniz
                using (HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("http://localhost:3534/api/Carts/getcart/3"))
                {
                    if (!httpResponseMessage.IsSuccessStatusCode)
                    {
                        return null;
                    }
                    string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                    rootCart = JsonSerializer.Deserialize<Root<CartViewModel>>(contentResponse);
                }
            }
            return View(rootCart.Data);
        }
    }
}
