using OnlineShop.Core.DTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace OnlineShop.Client.Services.State
{
    public class ShopState
    {
        private readonly HttpClient _client;

        private Lazy<List<Shop>> _cache;

        public ShopState(HttpClient client)
        {
            _client = client;
            _cache = new Lazy<List<Shop>>();
        }

        public async Task<List<Shop>> Fetch()
        {
            if (_cache.IsValueCreated)
                return _cache.Value;
            
            var shops = await _client.GetFromJsonAsync<List<Shop>>("/api/shop") ?? new List<Shop>();
            _cache = new Lazy<List<Shop>>(shops);
            return shops;
        }
    }
}