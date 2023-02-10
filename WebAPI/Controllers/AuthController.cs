using Business.Abstract;
using Entities.Dtos.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   public class AuthController:Controller
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.LoginAsync(userForLoginDto);
            if (!userToLogin.Result.Success)
            {
                return BadRequest(userToLogin.Result.Message);
            }

            var result = _authService.CreateAccessToken(userToLogin.Result.Data);
            if (result.Result.Success)
            {
                return Ok(result.Result.Data);
            }

            return BadRequest(result.Result.Message);
        }

        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExistsAsync(userForRegisterDto.Email);
            if (!userExists.Result.Success)
            {
                return BadRequest(userExists.Result.Message);
            }

            var registerResult = _authService.RegisterAsync(userForRegisterDto,userForRegisterDto.Password);
            var result = _authService.CreateAccessToken(registerResult.Result.Data);
            if (result.Result.Success)
            {
                return Ok(result.Result.Data);
            }

            return BadRequest(result.Result.Message);
        }
    }
}
