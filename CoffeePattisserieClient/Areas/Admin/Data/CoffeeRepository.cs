using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeePattisserieClient.Areas.Admin.Models;
using Newtonsoft.Json;

namespace CoffeePattisserieClient.Areas.Admin.Data
{
    public static class CoffeeRepository
    {
        public static async Task<List<CoffeeModel>> GetAllAsync()
        {
            var rootCoffees = new Root<List<CoffeeModel>>();
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("http://localhost:3534/api/coffees/getall"))
                {
                    if (!httpResponseMessage.IsSuccessStatusCode)
                    {
                        return null;
                    }
                    string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                    rootCoffees = System.Text.Json.JsonSerializer.Deserialize<Root<List<CoffeeModel>>>(contentResponse);
                }
            }
            return rootCoffees.Data;
        }

        public static async Task<CoffeeModel> GetByIdAsync(int id)
        {
            var rootCoffee = new Root<CoffeeModel>();
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage httpResponseMessage = await httpClient.GetAsync($"http://localhost:3534/api/coffees/{id}"))
                {
                    if (!httpResponseMessage.IsSuccessStatusCode)
                    {
                        return null;
                    }
                    string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                    rootCoffee = JsonConvert.DeserializeObject<Root<CoffeeModel>>(contentResponse);
                }
            }
            return rootCoffee.Data;
        }

        public static async Task Delete(int id)
        {
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.DeleteAsync($"http://localhost:3534/api/coffees/{id}");
            }
        }
    }
}
