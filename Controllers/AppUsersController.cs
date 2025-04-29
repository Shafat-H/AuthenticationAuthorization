using AuthenticationAuthorization.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> GetUser(long UserId)
        {
            var data = await _IRepository.GetUser(UserId);
            return Ok(data);
        }

    }
}
