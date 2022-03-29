using System;

namespace OnlineShop.Core.DTO
{
    public record UserData(string Name, bool IsAdmin, DateTime Register);
}