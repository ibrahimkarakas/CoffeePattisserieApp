using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeePattisserieClient.Areas.Admin.Models;
using Newtonsoft.Json;

namespace CoffeePattisserieClient.Areas.Admin.Data
{
    public static class MoctailRepository
    {
        public static async Task<List<MoctailModel>> GetAllAsync()
        {
            var rootMoctails = new Root<List<MoctailModel>>();
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("http://localhost:3534/api/moctails/getall"))
                {
                    if (!httpResponseMessage.IsSuccessStatusCode)
                    {
                        return null;
                    }
                    string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                    rootMoctails = System.Text.Json.JsonSerializer.Deserialize<Root<List<MoctailModel>>>(contentResponse);
                }
            }
            return rootMoctails.Data;
        }

        public static async Task<MoctailModel> GetByIdAsync(int id)
        {
            var rootMoctail = new Root<MoctailModel>();
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage httpResponseMessage = await httpClient.GetAsync($"http://localhost:3534/api/moctails/{id}"))
                {
                    if (!httpResponseMessage.IsSuccessStatusCode)
                    {
                        return null;
                    }
                    string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                    rootMoctail = JsonConvert.DeserializeObject<Root<MoctailModel>>(contentResponse);
                }
            }
            return rootMoctail.Data;
        }

        public static async Task Delete(int id)
        {
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.DeleteAsync($"http://localhost:3534/api/moctails/{id}");
            }
        }
    }
}
