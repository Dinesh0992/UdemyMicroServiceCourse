using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;
using eCommerce.Core.Validators;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")]//api/auth
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        //Enpoint for user registration user case 
        [HttpPost("register")] 
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            if (registerRequest == null) 
            {
                return BadRequest("Invalid Registration Data");
            }

            AuthenticationResponse? authenticationResponse = await _userService.Register(registerRequest);

           if(authenticationResponse==null || authenticationResponse.Success == false)
            {
                return Unauthorized(authenticationResponse);
            }
           return  Ok(authenticationResponse);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            LoginRequestValidator loginRequestValidator=new LoginRequestValidator();
            loginRequestValidator.ValidateAndThrow(loginRequest);

            if (loginRequest == null)
            {
                return BadRequest("Invalid Login Data");
            }

            AuthenticationResponse? authenticationResponse = await _userService.Login(loginRequest);

            if (authenticationResponse == null || authenticationResponse.Success == false)
            {
                return Unauthorized(authenticationResponse);
            }
            return Ok(authenticationResponse);
        }

    }
}
