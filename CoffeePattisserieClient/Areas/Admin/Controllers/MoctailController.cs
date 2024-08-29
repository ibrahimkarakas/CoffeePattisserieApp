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
    public class MoctailController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var moctails = await MoctailRepository.GetAllAsync();
            return View(moctails);
        }

        public async Task<IActionResult> Create()
        {
            var categories = await CategoryRepository.GetAllAsync();
            AddMoctailModel moctailModel = new AddMoctailModel
            {
                CategoryList = categories
            };
            return View(moctailModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddMoctailModel addMoctailModel, IFormFile image)
        {
            if (ModelState.IsValid && addMoctailModel.CategoryIds != null && image != null)
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
                        HttpResponseMessage responseMessage = await httpClient.PostAsync("http://localhost:3534/api/moctails/addimage", imageContent);
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
                    addMoctailModel.ImageUrl = imageUrl;
                    // Moctail ekleme
                    var serializeModel = System.Text.Json.JsonSerializer.Serialize(addMoctailModel);
                    var stringContent = new StringContent(serializeModel, Encoding.UTF8, "application/json");
                    var result = await httpClient.PostAsync("http://localhost:3534/api/moctails", stringContent);
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }

            addMoctailModel.CategoryList = await CategoryRepository.GetAllAsync();
            ViewBag.CategoryErrorMessage = addMoctailModel.CategoryIds == null ? "En az bir kategori seçilmelidir" : null;
            ViewBag.ImageErrorMessage = image == null ? "Resim seçiniz" : null;
            return View(addMoctailModel);
        }

        public async Task<IActionResult> Update(int id)
        {
            var moctail = await MoctailRepository.GetByIdAsync(id);
            var categories = await CategoryRepository.GetAllAsync();

            EditMoctailModel moctailModel = new EditMoctailModel
            {
                CategoryList = categories,
                Id = moctail.Id,
                Name = moctail.Name,
                CategoryIds = moctail.Categories.Select(x => x.Id).ToList(),
                ImageUrl = moctail.ImageUrl,
                Ingredients = moctail.Ingredients,
                PreparationMethod = moctail.PreparationMethod,
                Price = moctail.Price,
                StockQuantity = moctail.StockQuantity
            };
            return View(moctailModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(EditMoctailModel editMoctailModel, IFormFile image)
        {
            if (ModelState.IsValid && editMoctailModel.CategoryIds != null)
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
                            HttpResponseMessage responseMessage = await httpClient.PostAsync("http://localhost:3534/api/moctails/addimage", imageContent);
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
                        editMoctailModel.ImageUrl = imageUrl;
                    }

                    var serializeModel = JsonConvert.SerializeObject(editMoctailModel);
                    StringContent stringContent = new StringContent(serializeModel, Encoding.UTF8, "application/json");
                    HttpResponseMessage result = await httpClient.PutAsync("http://localhost:3534/api/moctails", stringContent);
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            var categories = await CategoryRepository.GetAllAsync();
            editMoctailModel.CategoryList = categories;
            ViewBag.CategoryErrorMessage = editMoctailModel.CategoryIds == null ? "En az bir kategori seçilmelidir" : null;
            ViewBag.ImageErrorMessage = image == null ? "Resim seçiniz" : null;
            return View(editMoctailModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await MoctailRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
