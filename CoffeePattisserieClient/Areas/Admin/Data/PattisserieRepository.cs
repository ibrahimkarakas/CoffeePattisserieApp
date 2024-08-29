using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeePattisserieClient.Areas.Admin.Models;
using Newtonsoft.Json;

namespace CoffeePattisserieClient.Areas.Admin.Data
{
    public static class PattisserieRepository
    {
        public static async Task<List<PattisserieModel>> GetAllAsync()
        {
            var rootPattisseries = new Root<List<PattisserieModel>>();
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("http://localhost:3534/api/pattisseries/getall"))
                {
                    if (!httpResponseMessage.IsSuccessStatusCode)
                    {
                        return null;
                    }
                    string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                    rootPattisseries = System.Text.Json.JsonSerializer.Deserialize<Root<List<PattisserieModel>>>(contentResponse);
                }
            }
            return rootPattisseries.Data;
        }

        public static async Task<PattisserieModel> GetByIdAsync(int id)
        {
            var rootPattisserie = new Root<PattisserieModel>();
            using (var httpClient = new HttpClient())
            {
                using (HttpResponseMessage httpResponseMessage = await httpClient.GetAsync($"http://localhost:3534/api/pattisseries/{id}"))
                {
                    if (!httpResponseMessage.IsSuccessStatusCode)
                    {
                        return null;
                    }
                    string contentResponse = await httpResponseMessage.Content.ReadAsStringAsync();
                    rootPattisserie = JsonConvert.DeserializeObject<Root<PattisserieModel>>(contentResponse);
                }
            }
            return rootPattisserie.Data;
        }

        public static async Task Delete(int id)
        {
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.DeleteAsync($"http://localhost:3534/api/pattisseries/{id}");
            }
        }
    }
}
