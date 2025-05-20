using AuthenticationAuthorization.Helper;
using AuthenticationAuthorization.Models;

namespace AuthenticationAuthorization.IRepository
{
    public interface IAppUsers
    {
        Task<User> GetUser(long UserId);
        Task<List<User>> GetAllUser(long UserId);

        Task<MessageHelper> CreateUser(User user);
        Task<MessageHelper> UserLogin(string UserName, string Password);

    }
}
