using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using PillowFight.Api.Models;
using PillowFight.BusinessServices;
using PillowFight.Repositories.Enumerations;
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



        #region AuthCode

        private int _UserId => Convert.ToInt32(User.Claims.FirstOrDefault().Value);

        [HttpPost("CreateCharacter")]
        public async Task<ActionResult> CreateCharacter(CharacterCreationDetails details)
        {
            return Ok(await _playerBL.CreatePlayerCharacterAsync(_UserId, details.Name, (CharacterClassEnum)Enum.Parse(typeof(CharacterClassEnum), details.CharacterClass)));
        }

        [HttpGet("DeleteCharacter")]
        public async Task<ActionResult> DeleteCharacter(int characterId)
        {
            return Ok(await _playerBL.DeletePlayerCharacterAsync(_UserId, characterId));
        }

        // Hmm, maybe return the updated Character instead of a bool indicating the operation was successful?
        [HttpGet("EquipCharacter")]
        public async Task<ActionResult<bool>> EquipCharacter(int characterId, int itemId)
        {
            return Ok(await _playerBL.EquipCharacterAsync(_UserId, characterId, itemId));
        }

        [HttpGet("Character")]
        public async Task<ActionResult<PlayerCharacter>> GetCharacter(int characterId)
        {
            var playerCharacter = await _playerBL.GetPlayerCharacterAsync(_UserId, characterId);

            if (playerCharacter == null)
            {
                return NotFound();
            }

            return Ok(new PlayerCharacter(playerCharacter));
        }

        [HttpGet("Characters")]
        public async Task<ActionResult<IEnumerable<PlayerCharacter>>> GetCharacters()
        {
            var characters = await _playerBL.GetPlayerCharactersAsync(_UserId);
            return Ok(characters.Select(p_character => new PlayerCharacter(p_character)));
        }

        [HttpGet("PlayerInventory")]
        public async Task<ActionResult<IEnumerable<InventoryItem>>> GetPlayerInventory()
        {
            return Ok((await _playerBL.GetPlayerInventoryAsync(_UserId)).Select(l_inventoryItem => new InventoryItem(l_inventoryItem)));
        }

        [HttpGet("Logout")]
        public async Task<ActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return SignOut();
        }

        [HttpGet("Unequip")]
        public async Task<ActionResult> UnequipCharacter(int characterId, ItemSlotEnum slot)
        {
            await _playerBL.UnequipCharacterAsync(_UserId, characterId, slot);
            return Ok();
        }

        #endregion
    }
}
