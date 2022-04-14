using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OnlineShop.Core.DTO;
using OnlineShop.Core.Model;
using OnlineShop.Server.Services;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OnlineShop.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly SymmetricSecurityKey _securityKey;
        private readonly IUserRepository _userRepository;

        public AuthController(SymmetricSecurityKey securityKey, IUserRepository userRepository)
        {
            _securityKey = securityKey;
            _userRepository = userRepository;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<UserData>> GetUserInfo()
        {
            JwtSecurityToken? jwtSecurityToken = HttpContext.Request.GetToken();
            if (jwtSecurityToken == null)
                return Unauthorized();

            var payload = jwtSecurityToken.GetPayload<JWTPayload>();
            var user = await _userRepository.GetById(payload.UserId);
            if (user == null)
                return Unauthorized();

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserData>> Post([FromBody] UserCredentials credentials)
        {
            var registered = await _userRepository.GetByName(credentials.UserName);
            if (registered != null)
                return BadRequest();

            var user = await _userRepository.RegisterUser(credentials);
            if (user == null)
                return BadRequest();

            var jwtToken = NewToken(user.Id, user.IsAdmin);
            var userInfo = user.Adapt<UserData>();

            HttpContext.Response.Headers.Append("WWW-Authenticate", "Bearer " + jwtToken);
            HttpContext.Response.Cookies.Append("_token", jwtToken);
            return Ok(userInfo);
        }

        [HttpPut]
        public async Task<ActionResult<UserData>> Put([FromBody] UserCredentials credentials)
        {
            User? logonUser = await _userRepository.LoginUser(credentials);
            if (logonUser == null)
                return BadRequest();

            var jwtToken = NewToken(logonUser.Id, logonUser.IsAdmin);
            var userInfo = logonUser.Adapt<UserData>();

            HttpContext.Response.Headers.Append("WWW-Authenticate", "Bearer " + jwtToken);
            HttpContext.Response.Cookies.Append("_token", jwtToken);
            return Ok(userInfo);
        }

        private string NewToken(int userId, bool isAdmin)
        {
            var signingCredentials = new SigningCredentials(_securityKey, SecurityAlgorithms.HmacSha256);

            var claimsdata = new[] {new Claim(ClaimTypes.Role, isAdmin ? "Admin" : "User")};

            var securityToken = new JwtSecurityToken(
                issuer: "blazor.app",
                audience: "blazor.users",
                signingCredentials: signingCredentials,
                expires: DateTime.Now.AddHours(10),
                claims: claimsdata
            );
            securityToken.SetPayload(new JWTPayload(userId));

            JwtSecurityTokenHandler tokenHandler = new();
            return tokenHandler.WriteToken(securityToken);
        }
    }
}