using OnlineShop.Core.DTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace OnlineShop.Client.Services.State
{
    public class AppState
    {
        public event Action StateChanged;
        public UserState? UserState { get; private set; }
        
        private readonly HttpClient _client;

        public AppState(HttpClient client)
        {
            _client = client;
        }

        public void SetUserState(UserState state)
        {
            UserState = state;
            StateChanged?.Invoke();
        }

        public async Task<List<UserData>> FetchUsers()
        {
            return await Task.CompletedTask.ContinueWith((t) => new List<UserData>()
            {
                new UserData(0, "ASD", false, DateTime.Today),
                new UserData(1, "ASDW", true, DateTime.Today),
                new UserData(2, "ASDD", false, DateTime.Today),
                new UserData(3, "ASDC", false, DateTime.Today),
            });
        }
    }
}