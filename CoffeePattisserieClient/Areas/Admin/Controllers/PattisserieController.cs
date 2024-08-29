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
    public class PattisserieController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var pattisseries = await PattisserieRepository.GetAllAsync();
            return View(pattisseries);
        }

        public async Task<IActionResult> Create()
        {
            var categories = await CategoryRepository.GetAllAsync();
            AddPattisserieModel pattisserieModel = new AddPattisserieModel
            {
                CategoryList = categories
            };
            return View(pattisserieModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddPattisserieModel addPattisserieModel, IFormFile image)
        {
            if (ModelState.IsValid && addPattisserieModel.CategoryIds != null && image != null)
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
                        HttpResponseMessage responseMessage = await httpClient.PostAsync("http://localhost:3534/api/pattisseries/addimage", imageContent);
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
                    addPattisserieModel.ImageUrl = imageUrl;
                    // Pattisserie ekleme
                    var serializeModel = System.Text.Json.JsonSerializer.Serialize(addPattisserieModel);
                    var stringContent = new StringContent(serializeModel, Encoding.UTF8, "application/json");
                    var result = await httpClient.PostAsync("http://localhost:3534/api/pattisseries", stringContent);
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }

            addPattisserieModel.CategoryList = await CategoryRepository.GetAllAsync();
            ViewBag.CategoryErrorMessage = addPattisserieModel.CategoryIds == null ? "En az bir kategori seçilmelidir" : null;
            ViewBag.ImageErrorMessage = image == null ? "Resim seçiniz" : null;
            return View(addPattisserieModel);
        }

        public async Task<IActionResult> Update(int id)
        {
            var pattisserie = await PattisserieRepository.GetByIdAsync(id);
            var categories = await CategoryRepository.GetAllAsync();

            EditPattisserieModel pattisserieModel = new EditPattisserieModel
            {
                CategoryList = categories,
                Id = pattisserie.Id,
                Name = pattisserie.Name,
                CategoryIds = pattisserie.Categories.Select(x => x.Id).ToList(),
                ImageUrl = pattisserie.ImageUrl,
                Ingredients = pattisserie.Ingredients,
                Allergens = pattisserie.Allergens,
                ShelfLife = pattisserie.ShelfLife,
                Price = pattisserie.Price,
                StockQuantity = pattisserie.StockQuantity
            };
            return View(pattisserieModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(EditPattisserieModel editPattisserieModel, IFormFile image)
        {
            if (ModelState.IsValid && editPattisserieModel.CategoryIds != null)
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
                            HttpResponseMessage responseMessage = await httpClient.PostAsync("http://localhost:3534/api/pattisseries/addimage", imageContent);
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
                        editPattisserieModel.ImageUrl = imageUrl;
                    }

                    var serializeModel = JsonConvert.SerializeObject(editPattisserieModel);
                    StringContent stringContent = new StringContent(serializeModel, Encoding.UTF8, "application/json");
                    HttpResponseMessage result = await httpClient.PutAsync("http://localhost:3534/api/pattisseries", stringContent);
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            var categories = await CategoryRepository.GetAllAsync();
            editPattisserieModel.CategoryList = categories;
            ViewBag.CategoryErrorMessage = editPattisserieModel.CategoryIds == null ? "En az bir kategori seçilmelidir" : null;
            ViewBag.ImageErrorMessage = image == null ? "Resim seçiniz" : null;
            return View(editPattisserieModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await PattisserieRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
