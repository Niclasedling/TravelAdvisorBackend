using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using TravelAdvisor.Infrastructure.Interfaces;
using TravelAdvisor.Infrastructure.Migrations.HelperClasses;
using TravelAdvisor.Infrastructure.Migrations.Models;
using TravelAdvisor.Infrastructure.Models;
using TravelAdvisor.Infrastructure.Services;

namespace TravelAdvisor.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public readonly IUserService _userService;
        



        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _logger = logger;
           

        }



        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var item = await _userService.GetById(id);
            return Ok(item);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var item = await _userService.GetAll();
            if(item == null)
            {
                return BadRequest("Item is null");
            }
            return Ok(item);

        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var item = await _userService.GetList();
            return Ok(item);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var item = await _userService.Delete(id);
            return Ok(item);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(UserCreateDto newUser)
        {
            var item = await _userService.Create(newUser);
            return Ok(item);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDto userLogin)
        {
            var item = await _userService.Login(userLogin);
            await Authenticate(item.Email);

            return Ok(item);
        }


        [HttpPut("Update")]
        public async Task<IActionResult> Update(UserUpdateDto userUpdate)
        {
            var item = await _userService.Update(userUpdate);
            return Ok(item);
        }


        [NonAction]
        private async Task Authenticate(string email)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, email)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }


        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok("Thanks for your visit!");
        }

    }
}
