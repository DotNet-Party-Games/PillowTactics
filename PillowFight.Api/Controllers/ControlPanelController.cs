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
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ControlPanelController : ControllerBase
    {
        readonly IPlayerBL _playerBL;

        public ControlPanelController(IServiceProvider serviceProvider)
        {
            _playerBL = serviceProvider.GetRequiredService<IPlayerBL>();
        }

        //private int _UserId => Convert.ToInt32(User.Claims.FirstOrDefault().Value);

        [HttpPost("CreateCharacter")]
        public async Task<ActionResult> CreateCharacter(int userId, CharacterCreationDetails details)
        {
            return Ok(await _playerBL.CreatePlayerCharacterAsync(userId, details.Name, (CharacterClassEnum)Enum.Parse(typeof(CharacterClassEnum), details.CharacterClass)));
        }

        [HttpGet("DeleteCharacter")]
        public async Task<ActionResult> DeleteCharacter(int userId, int characterId)
        {
            return Ok(await _playerBL.DeletePlayerCharacterAsync(userId, characterId));
        }

        // Hmm, maybe return the updated Character instead of a bool indicating the operation was successful?
        [HttpGet("EquipCharacter")]
        public async Task<ActionResult<bool>> EquipCharacter(int userId, int characterId, int itemId)
        {
            return Ok(await _playerBL.EquipCharacterAsync(userId, characterId, itemId));
        }

        [HttpGet("Character")]
        public async Task<ActionResult<PlayerCharacter>> GetCharacter(int userId, int characterId)
        {
            var playerCharacter = await _playerBL.GetPlayerCharacterAsync(userId, characterId);

            if (playerCharacter == null)
            {
                return NotFound();
            }

            return Ok(new PlayerCharacter(playerCharacter));
        }

        [HttpGet("Characters")]
        public async Task<ActionResult<IEnumerable<PlayerCharacter>>> GetCharacters(int userId)
        {
            var characters = await _playerBL.GetPlayerCharactersAsync(userId);
            return Ok(characters.Select(p_character => new PlayerCharacter(p_character)));
        }

        [HttpGet("PlayerInventory")]
        public async Task<ActionResult<IEnumerable<InventoryItem>>> GetPlayerInventory(int userId)
        {
            return Ok((await _playerBL.GetPlayerInventoryAsync(userId)).Select(l_inventoryItem => new InventoryItem(l_inventoryItem)));
        }

        [HttpGet("LeaderBoard")]
        public async Task<ActionResult<IEnumerable<PlayerDetails>>> GetLeaderBoard(int? n)
        {
            return Ok((await _playerBL.GetTopPlayersAsync(n)).Select(a_player => new PlayerDetails(a_player)));
        }

        #region AuthLogout
        /*
                [HttpGet("Logout")]
                public async Task<ActionResult> LogOut()
                {
                    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                    return Ok();
                }
        */
        #endregion

        [HttpGet("Unequip")]
        public async Task<ActionResult> UnequipCharacter(int userId, int characterId, ItemSlotEnum slot)
        {
            await _playerBL.UnequipCharacterAsync(userId, characterId, slot);
            return Ok();
        }
    }
}
