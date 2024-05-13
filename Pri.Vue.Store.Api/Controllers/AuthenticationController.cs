using Microsoft.AspNetCore.Mvc;
using Pri.Vue.Store.Api.Core.Interfaces.Services;
using Pri.Vue.Store.Api.Core.Models.Users;
using Pri.Vue.Store.Api.Dtos.Users;

namespace Pri.Vue.Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var registerModel = new RegisterModel
            {
                Email = registerDto.Email,
                Birthday = registerDto.Birthday,
                Password = registerDto.Password
            };

            var result = await _userService.RegisterAsync(registerModel);

            if (result.IsSuccess == false)
            {
                return BadRequest(result.Messages);
            }

            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var loginModel = new LoginModel
            {
                Email = loginDto.Email,
                Password = loginDto.Password
            };

            var result = await _userService.LoginAsync(loginModel);

            if (result.IsSuccess == false)
            {
                return BadRequest(result.Messages);
            }

            return Ok(new TokenDto { BearerToken = result.Token });
        }
    }
}
