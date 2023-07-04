using GymHubAPI.Exceptions;
using GymHubAPI.Models;
using GymHubAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymHubAPI.Controllers.User
{
 
    public class ReturnUserClass
    {
        public string Name;
        public string Token;
    }

    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
            private readonly IUserService _userService;

            public UserController(IUserService userService)
            {
                _userService = userService;
            }
            [HttpPost("register")]
            public ActionResult RegisterUser([FromBody] RegisterUserDto dto)
            {
                _userService.RegisterUser(dto);
                return Ok();
            }

            [HttpPost("login")]
            public ActionResult Login([FromBody] LoginUserDto dto)
            {
                string token = _userService.GenerateJwt(dto);
                var user = _userService.GetUser(dto);

            return Ok(new
                {
                    name = user.Name,
                    token = token
                });
            }
        }
}
