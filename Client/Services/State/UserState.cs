namespace OnlineShop.Client.Services.State
{
    public record UserState
    {
        public string UserName { get; set; } = null!;
        public bool Admin { get; set; } = false;
    }
}