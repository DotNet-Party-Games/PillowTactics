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

        private int _UserId => Convert.ToInt32(User.Claims.FirstOrDefault().Value);

        [HttpPost("CreateCharacter")]
        public async Task<ActionResult> CreateCharacter(CharacterCreationDetails details)
        {
            return Ok(await _playerBL.CreatePlayerCharacterAsync(_UserId, details.Name, details.Class));
        }

        [HttpGet("DeleteCharacter")]
        public async Task<ActionResult> DeleteCharacter(int characterId)
        {
            return Ok(await _playerBL.DeletePlayerCharacterAsync(_UserId, characterId));
        }

        [HttpGet("Character")]
        public async Task<ActionResult> GetCharacter(int characterId)
        {
            var playerCharacter = await _playerBL.GetPlayerCharacterAsync(_UserId, characterId);

            if (playerCharacter == null)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpGet("Characters")]
        public async Task<ActionResult<IEnumerable<PlayerCharacter>>> GetCharacters()
        {
            var characters = await _playerBL.GetPlayerCharactersAsync(_UserId);
            return Ok(characters.Select(p_character => new PlayerCharacter(p_character)));
        }

        [HttpGet("Logout")]
        public async Task<ActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return SignOut();
        }
    }
}
