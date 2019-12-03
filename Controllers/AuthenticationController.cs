using FacebookApi.Models;
using FacebookApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;

namespace FacebookApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        private readonly UserService _userService;
        private readonly AuthService _authService;

        public AuthenticationController(UserService userService, AuthService authService) {
            _userService = userService;
            _authService = authService;
        }

        [HttpPost("Signin")]
        public ActionResult<string> Signin(User user)
        {
            var userId = _userService.IsRegistered(user);
            if(String.IsNullOrEmpty(userId)) {
                return Unauthorized();
            }

            var token = _authService.Login(userId);

            return Ok(token);
        }

        [HttpPost("Signup")]
        public ActionResult<string> Signup(User user)
        {
            if(_userService.IsEmailUsed(user.Email)) {
                return Unauthorized();
            }
            _userService.Create(user);

            return Signin(user);
        }

        [HttpGet("Validate")]
        [Authorize]
        public ActionResult<string> Validate()
        {
            var userId = _authService.GetIdentity(HttpContext);
            return userId;
        }
    }
}
