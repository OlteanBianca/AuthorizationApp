﻿using AuthorizationApp.DTOs;
using AuthorizationApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AuthorizationApp.Controllers
{
    [ApiController]
    [Route("login")]
    [Authorize]
    public class LoginController : ControllerBase
    {
        #region Private Fields
        private readonly IUserService _userService;
        #endregion

        #region Constructors
        public LoginController(IUserService userService)
        {
            _userService = userService;
        }
        #endregion

        #region Public Methods

        [HttpPost("~/register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterDTO payload)
        {
            await _userService.Register(payload);
            return Ok();
        }

        [HttpPost("/login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginDTO payload)
        {
            var jwtToken = await _userService.Validate(payload);
            return Ok(new { token = jwtToken });
        }

        [HttpGet("test-auth")]
        public IActionResult TestLogin()
        {
            ClaimsPrincipal user = User;

            var result = "";

            foreach (var claim in user.Claims)
            {
                result += claim.Type + " : " + claim.Value + "\n";
            }
            var hasRole_user = user.IsInRole("User");
            var hasRole_teacher = user.IsInRole("Teacher");

            return Ok(result);
        }

       

        [HttpGet("teacher-only")]
        [Authorize(Roles = "Teacher")]
        public ActionResult<string> HelloTeachers()
        {
            return Ok("Hello teachers!");
        }
        #endregion
    }
}
