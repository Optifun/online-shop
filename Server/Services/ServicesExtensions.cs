using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;

namespace OnlineShop.Server.Services
{
   
    public static class JWTExtensions
    {
        public static T? GetPayload<T>(this JwtSecurityToken securityToken)
        {
            var content = (string)securityToken.Payload["content"];
            return JsonSerializer.Deserialize<T>(content);
        }

        public static void SetPayload<T>(this JwtSecurityToken securityToken, T content)
        {
            var str = JsonSerializer.Serialize(content);
            securityToken.Payload["content"] = str;
        }
    }
}