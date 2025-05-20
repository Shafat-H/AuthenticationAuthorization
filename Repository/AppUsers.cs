using AuthenticationAuthorization.DbContexts;
using AuthenticationAuthorization.Helper;
using AuthenticationAuthorization.IRepository;
using AuthenticationAuthorization.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthenticationAuthorization.Repository
{
    public class AppUsers : IAppUsers
    {
        public readonly Context _context;
        private readonly IConfiguration _configuration;
        public AppUsers(Context context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
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
        public async Task<List<User>> GetAllUser(long UserId)
        {
            try
            {
                var user = await _context.Users.ToListAsync();
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

        public async Task<MessageHelper> CreateUser(User user)
        {
            try
            {
                var userData = await _context.Users.Where(x => x.Username == user.Username).FirstOrDefaultAsync();
                if (userData != null)
                {
                    throw new Exception(user.Username + "User name already exists");
                }
                var newUser = new User
                {
                    Username = user.Username,
                    PasswordHash = user.PasswordHash,
                    Role = user.Role,
                    LastLoginDate = user.LastLoginDate,
                    IsActive = user.IsActive,
                    CreatedDate = user.CreatedDate,
                    UpdatedDate = user.UpdatedDate,
                };
                await _context.Users.AddAsync(newUser);
                await _context.SaveChangesAsync();

                return new MessageHelper { Status = 200, Message = "Successfully Created" };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<MessageHelper> UserLogin(string UserName, string Password)
        {
            var dt = _context.Users.Where(x => x.Username == UserName && x.PasswordHash == Password).FirstOrDefault();

            if (dt != null)
            {
                var token = GenerateJwtToken(dt);
                return new MessageHelper { Status = 200, Message = token };
            }
            return new MessageHelper { Status = 200, Message = "Unauthorized" };
        }
        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role), // Add other claims as needed
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),  // Set token expiration time
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
