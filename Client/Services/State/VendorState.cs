using OnlineShop.Core.DTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace OnlineShop.Client.Services.State
{
    public class VendorState
    {
        private readonly HttpClient _client;
        private Lazy<List<Vendor>> _cache;

        public VendorState(HttpClient client)
        {
            _client = client;
            _cache = new Lazy<List<Vendor>>();
        }
        
        public async Task<List<Vendor>> Fetch()
        {
            if (_cache.IsValueCreated)
                return _cache.Value;
            
            var vendors = await _client.GetFromJsonAsync<List<Vendor>>("/api/Vendor") ?? new List<Vendor>();
            _cache = new Lazy<List<Vendor>>(vendors);
            return vendors;
        }
    }
}