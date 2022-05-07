using OnlineShop.Core.DTO;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace OnlineShop.Client.Services.State
{
    public class ShopState
    {
        private readonly HttpClient _client;

        public ShopState(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<Shop>> Fetch()
        {
            var shops = await _client.GetFromJsonAsync<List<Shop>>("/api/shop");
            return shops ?? new List<Shop>();
        }
    }
}