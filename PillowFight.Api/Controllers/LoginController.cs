using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using PillowFight.Api.Models;
using PillowFight.BusinessServices;
using PillowFight.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PillowFight.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        readonly IPlayerBL _playerBL;

        public LoginController(IServiceProvider serviceProvider)
        {
            _playerBL = serviceProvider.GetRequiredService<IPlayerBL>();
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(PlayerRegistrationDetails details)
        {
            await _playerBL.CreatePlayerAsync(details.UserName, details.Password, details.Email);
            return Accepted();
        }

        [HttpPost("Login")]
        public async Task<ActionResult<PlayerDetails>> LogIn(PlayerLoginDetails details)
        {
            Player player;

            player = await _playerBL.GetPlayerAsync(details.UserName, details.Password);
            if (player == null)
            {
                return NotFound();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, player.Id.ToString())
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true
            };

            await HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity), authProperties);

            return Ok(new PlayerDetails()
            {
                UserName = player.UserName,
                Email = player.Email,
                Wins = player.Wins,
                Losses = player.Losses
            });
        }
    }
}
