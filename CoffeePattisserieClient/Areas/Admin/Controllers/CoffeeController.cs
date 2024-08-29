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
    public class CoffeeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var coffees = await CoffeeRepository.GetAllAsync();
            return View(coffees);
        }

        public async Task<IActionResult> Create()
        {
            var categories = await CategoryRepository.GetAllAsync();
            AddCoffeeModel coffeeModel = new AddCoffeeModel
            {
                CategoryList = categories
            };
            return View(coffeeModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddCoffeeModel addCoffeeModel, IFormFile image)
        {
            if (ModelState.IsValid && addCoffeeModel.CategoryIds != null && image != null)
            {
                using (var httpClient = new HttpClient())
                {
                    var imageUrl = "";
                    // Resim yükleme/ekleme
                    using (var stream = image.OpenReadStream())
                    {
                        var imageContent = new MultipartFormDataContent();
                        byte[] bytes = stream.ToByteArray();
                        imageContent.Add(new ByteArrayContent(bytes), "file", image.FileName);
                        HttpResponseMessage responseMessage = await httpClient.PostAsync("http://localhost:3534/api/coffees/addimage", imageContent);
                        var responseString = await responseMessage.Content.ReadAsStringAsync();
                        var response = JsonConvert.DeserializeObject<Root<ImageModel>>(responseString);
                        if (response.IsSucceeded)
                        {
                            imageUrl = response.Data.ImageUrl;
                        }
                        else
                        {
                            Console.Write(response.Error);
                        }
                    }
                    addCoffeeModel.ImageUrl = imageUrl;
                    // Kahve ekleme
                    var serializeModel = System.Text.Json.JsonSerializer.Serialize(addCoffeeModel);
                    var stringContent = new StringContent(serializeModel, Encoding.UTF8, "application/json");
                    var result = await httpClient.PostAsync("http://localhost:3534/api/coffees", stringContent);
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }

            addCoffeeModel.CategoryList = await CategoryRepository.GetAllAsync();
            ViewBag.CategoryErrorMessage = addCoffeeModel.CategoryIds == null ? "En az bir kategori seçilmelidir" : null;
            ViewBag.ImageErrorMessage = image == null ? "Resim seçiniz" : null;
            return View(addCoffeeModel);
        }

        public async Task<IActionResult> Update(int id)
        {
            var coffee = await CoffeeRepository.GetByIdAsync(id);
            var categories = await CategoryRepository.GetAllAsync();

            EditCoffeeModel coffeeModel = new EditCoffeeModel
            {
                CategoryList = categories,
                Id = coffee.Id,
                Name = coffee.Name,
                CategoryIds = coffee.Categories.Select(x => x.Id).ToList(),
                ImageUrl = coffee.ImageUrl,
                OriginCountry = coffee.OriginCountry,
                RoastLevel = coffee.RoastLevel,
                FlavorNotes = coffee.FlavorNotes,
                Price = coffee.Price,
                StockQuantity = coffee.StockQuantity
            };
            return View(coffeeModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(EditCoffeeModel editCoffeeModel, IFormFile image)
        {
            if (ModelState.IsValid && editCoffeeModel.CategoryIds != null)
            {
                using (var httpClient = new HttpClient())
                {
                    if (image != null)
                    {
                        var imageUrl = "";
                        // Resim yükleme/ekleme
                        using (var stream = image.OpenReadStream())
                        {
                            var imageContent = new MultipartFormDataContent();
                            byte[] bytes = stream.ToByteArray();
                            imageContent.Add(new ByteArrayContent(bytes), "file", image.FileName);
                            HttpResponseMessage responseMessage = await httpClient.PostAsync("http://localhost:3534/api/coffees/addimage", imageContent);
                            var responseString = await responseMessage.Content.ReadAsStringAsync();
                            var response = JsonConvert.DeserializeObject<Root<ImageModel>>(responseString);
                            if (response.IsSucceeded)
                            {
                                imageUrl = response.Data.ImageUrl;
                            }
                            else
                            {
                                Console.Write(response.Error);
                            }
                        }
                        editCoffeeModel.ImageUrl = imageUrl;
                    }

                    var serializeModel = JsonConvert.SerializeObject(editCoffeeModel);
                    StringContent stringContent = new StringContent(serializeModel, Encoding.UTF8, "application/json");
                    HttpResponseMessage result = await httpClient.PutAsync("http://localhost:3534/api/coffees", stringContent);
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            var categories = await CategoryRepository.GetAllAsync();
            editCoffeeModel.CategoryList = categories;
            ViewBag.CategoryErrorMessage = editCoffeeModel.CategoryIds == null ? "En az bir kategori seçilmelidir" : null;
            ViewBag.ImageErrorMessage = image == null ? "Resim seçiniz" : null;
            return View(editCoffeeModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await CoffeeRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
