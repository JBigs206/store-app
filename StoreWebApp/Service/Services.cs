using System;
using System.Collections.Generic;
using System.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using StoreWebApp.Models;

namespace StoreWebApp.Service
{
    public static class Services
    {
        public static async Task<List<ProductModel>> GetDataFromAPIAsync()
        {
            string BaseUrl = ConfigurationManager.AppSettings["store_api"];

            var Products = new List<ProductModel>();

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(BaseUrl),
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Products = JsonConvert.DeserializeObject<List<ProductModel>>(body);
                for (int i = 0; i < Products.Count; i++)
                {
                    Products[i].Description = Products[i].Description.Length <= 100 ? Products[i].Description : Products[i].Description.Substring(0, 100) + "...";
                }
                return Products;
            }
        }

        public static async Task<ProductModel> GetProductByIdAsync(int id = 0)
        {
            string BaseUrl = ConfigurationManager.AppSettings["store_api"];

            var Product = new ProductModel();

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(BaseUrl + id),
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Product = JsonConvert.DeserializeObject<ProductModel>(body);
                
                return Product;
            }
        }
    }
}