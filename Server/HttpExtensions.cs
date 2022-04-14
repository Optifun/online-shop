using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace OnlineShop.Server
{
    public static class HttpExtensions
    {
        public static JwtSecurityToken? GetToken(this HttpRequest request)
        {
            string? authHeader = request.Headers["Authorization"].FirstOrDefault();
            if (authHeader == null)
                return null;
            
            JwtSecurityToken securityToken = new JwtSecurityTokenHandler().ReadJwtToken(authHeader.Split(" ").Last());
            return securityToken;
        }
    }
}