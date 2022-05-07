using OnlineShop.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace OnlineShop.Client.Services.State
{
    public class CategoryState
    {
        private readonly HttpClient _client;
        private Lazy<List<Category>> _cache;

        public CategoryState(HttpClient client)
        {
            _client = client;
            _cache = new Lazy<List<Category>>();
        }

        public async Task<List<Category>> Fetch()
        {
            if (_cache.IsValueCreated)
                return _cache.Value;
            
            var categories = await _client.GetFromJsonAsync<List<Category>>("/api/Category") ?? new List<Category>();
            _cache = new Lazy<List<Category>>(categories);
            return categories;
        }
    }
}