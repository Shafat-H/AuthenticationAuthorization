using AuthenticationAuthorization.Helper;
using AuthenticationAuthorization.IRepository;
using AuthenticationAuthorization.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthenticationAuthorization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AppUsersController : ControllerBase
    {
        private readonly IAppUsers _IRepository;

        public AppUsersController(IAppUsers IRepository)
        {
            _IRepository = IRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUser(long UserId)
        {
            var data = await _IRepository.GetUser(UserId);
            return Ok(data);
        }
        [HttpGet]
        [Route("AllUser")]
        public async Task<IActionResult> GetAllUser(long UserId)
        {
            var data = await _IRepository.GetAllUser(UserId);
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            var data = await _IRepository.CreateUser(user);
            return Ok(data);
        }
        [HttpGet]
        [Route("Login")]
        public async Task<IActionResult> UserLogin(string UserName ,string Password )
        {
            var data = await _IRepository.UserLogin(UserName, Password);
            return Ok(data);
        }




    }
}
