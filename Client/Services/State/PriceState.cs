using OnlineShop.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace OnlineShop.Client.Services.State
{
    public class PriceState
    {
        private readonly HttpClient _client;

        public PriceState(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<Price>> Fetch(long productId)
        {
            var products = await _client.GetFromJsonAsync<List<Price>>($"/api/price/{productId}") ?? new List<Price>();
            return products;
        }

        public async Task<bool> SetPrice(long productId, Price price)
        {
            var response = await _client.PutAsJsonAsync($"/api/price/{productId}", price);
            return response.IsSuccessStatusCode;
        }
    }
}