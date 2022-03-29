using OnlineShop.Core.DTO;
using OnlineShop.Core.Model;
using System.Threading.Tasks;
using User = OnlineShop.Core.Model.User;

namespace OnlineShop.Server.Services
{
    public interface IUserRepository
    {
        public Task<User?> RegisterUser(UserCredentials credentials);
        public Task<User?> LoginUser(UserCredentials credentials);
        public Task<User?> GetById(long id);

        public Task<User?> GetByName(string username);
    }
}