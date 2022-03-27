using System;
using System.Net.Http;

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
    }
}