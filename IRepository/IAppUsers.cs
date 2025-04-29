using AuthenticationAuthorization.Models;

namespace AuthenticationAuthorization.IRepository
{
    public interface IAppUsers
    {
        Task<User> GetUser(long UserId);
    }
}
