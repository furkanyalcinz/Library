using Business.Abstract;
using Business.Schema.User;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody]LoginSchema loginSchema)
        {

            var result = _userService.Login(loginSchema);
            return Ok(result);
        }
        [HttpPost("Register")]
        public IActionResult Register([FromBody]User user)
        {
            var result = _userService.Register(user);
            return Ok(result);
        }
    }
}
