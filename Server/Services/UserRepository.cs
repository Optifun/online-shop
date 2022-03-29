using Mapster;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.DTO;
using OnlineShop.Server.DataAccess;
using System.Threading.Tasks;
using User = OnlineShop.Core.Model.User;

namespace OnlineShop.Server.Services
{
    class UserRepository : IUserRepository
    {
        private OnlineShopContext _context;

        public UserRepository(OnlineShopContext context)
        {
            _context = context;
        }

        public async Task<User?> RegisterUser(UserCredentials credentials)
        {
            var registered = await GetByName(credentials.UserName);
            if (registered != null)
                return null;

            DataAccess.User userEntry = new() {Name = credentials.UserName, PasswordHash = credentials.PasswordHash, IsAdmin = false};

            var user = await _context.Users.AddAsync(userEntry);
            await _context.SaveChangesAsync();
            return user.Entity.Adapt<User>();
        }

        public async Task<User?> LoginUser(UserCredentials credentials)
        {
            DataAccess.User? user = await _context.Users.FirstOrDefaultAsync(user => user.Name == credentials.UserName && user.PasswordHash == credentials.PasswordHash);
            return user?.Adapt<User>();
        }

        public async Task<User?> GetById(long id)
        {
            DataAccess.User? user = await _context.Users.FirstOrDefaultAsync(user => user.Id == id);
            return user?.Adapt<User>();
        }

        public async Task<User?> GetByName(string username)
        {
            DataAccess.User? user = await _context.Users.FirstOrDefaultAsync(user => user.Name == username);
            return user?.Adapt<User>();
        }
    }
}