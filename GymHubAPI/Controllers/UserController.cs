using GymHubAPI.Models;
using GymHubAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymHubAPI.Controllers.User
{
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
    } 
}
