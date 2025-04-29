using AuthenticationAuthorization.DbContexts;
using AuthenticationAuthorization.IRepository;
using AuthenticationAuthorization.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationAuthorization.Repository
{
    public class AppUsers : IAppUsers
    {
        public readonly Context _context;
        public AppUsers(Context context)
        {
            _context = context;
        }
        public async Task<User> GetUser(long UserId)
        {
            try
            {
                var user = await _context.Users.Where(x => x.UserId == UserId).FirstOrDefaultAsync();
                if (user == null)
                {
                    throw new Exception("User Not Found");
                }
                return user;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
