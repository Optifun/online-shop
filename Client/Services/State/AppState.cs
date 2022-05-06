using OnlineShop.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OnlineShop.Client.Services.State
{
    public class AppState
    {
        public event Action StateChanged;
        public UserState? CurrentUser { get; private set; }
        public ProductState Product { get; private set; }

        public VendorState Vendor { get; private set; }
        public CategoryState Category { get; private set; }
        public PriceState Price { get; private set; }
        
        private readonly HttpClient _client;

        public AppState(HttpClient client)
        {
            _client = client;
            Product = new ProductState();
            Vendor = new VendorState();
            Category = new CategoryState();
            Price = new PriceState();
        }

        public void SetUserState(UserState state)
        {
            CurrentUser = state;
            StateChanged?.Invoke();
        }

        public async Task<List<UserMutable>> FetchUsers()
        {
            var users = await Task.CompletedTask.ContinueWith((t) => new List<UserData>()
            {
                new(0, "ASD", false, DateTime.Today),
                new(1, "ASDW", true, DateTime.Today),
                new(2, "ASDD", false, DateTime.Today),
                new(3, "ASDC", false, DateTime.Today),
                new(4, "Masha", false, DateTime.Today),
                new(4, "Danil", true, DateTime.Today),
            });
            return users.Select(user => new UserMutable(user)).ToList();
        }

        public async Task<UserMutable> UpdateUser(UserMutable user)
        {
            return user;
        }
    }
}