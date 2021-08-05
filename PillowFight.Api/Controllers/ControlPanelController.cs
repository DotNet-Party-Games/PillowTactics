using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using PillowFight.Api.Models;
using PillowFight.BusinessServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PillowFight.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ControlPanelController : ControllerBase
    {
        readonly IPlayerBL _playerBL;

        public ControlPanelController(IServiceProvider serviceProvider)
        {
            _playerBL = serviceProvider.GetRequiredService<IPlayerBL>();
        }

        [HttpGet("Characters")]
        public async Task<ActionResult<IEnumerable<PlayerCharacter>>> GetCharacters()
        {
            var characters = await _playerBL.GetPlayerCharactersAsync(Convert.ToInt32(User.Claims.FirstOrDefault().Value));
            return Ok(characters.Select(p_character => new PlayerCharacter()
            {
                Class = p_character.Class,
                Strength = p_character.Strength,
                Dexterity = p_character.Dexterity,
                Constitution = p_character.Constitution,
                Intelligence = p_character.Intelligence,
                Wisdom = p_character.Wisdom,
                MainHandSlotItem = new Weapon()
                {
                    Name = p_character.MainHandSlotItem.Name,
                    Attack = p_character.MainHandSlotItem.Attack,
                    Range = p_character.MainHandSlotItem.Range

                },
                TorsoSlotItem = new Armor()
                {
                    Name = p_character.TorsoSlotItem.Name,
                    Defense = p_character.TorsoSlotItem.Defense
                }
            }));
        }

        [HttpGet("Logout")]
        public async Task<ActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok();
        }
    }
}
