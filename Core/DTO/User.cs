using System;

namespace OnlineShop.Core.DTO
{
    public record UserData(long Id, string Name, bool IsAdmin, DateTime Register);
    
    public record UserCredentials(string UserName, string PasswordHash);
}