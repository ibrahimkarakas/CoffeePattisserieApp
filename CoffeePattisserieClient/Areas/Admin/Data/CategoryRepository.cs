using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeePattisserieClient.Areas.Admin.Models;


namespace CoffeePattisserieClient.Areas.Admin.Data
{
   public static class CategoryRepository
{
    public static async Task<List<CategoryModel>> GetAllAsync()
    {
        var rootCategories = new Root<List<CategoryModel>>();
        using (var httpClient = new HttpClient())
        {
            using (HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("http://localhost:3534/api/categories"))
            {
                if (!httpResponseMessage.IsSuccessStatusCode)
                {
                    return null;
                }
                string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                rootCategories = System.Text.Json.JsonSerializer.Deserialize<Root<List<CategoryModel>>>(contentResponse);
            }
        }
        return rootCategories.Data;
    }
}
}