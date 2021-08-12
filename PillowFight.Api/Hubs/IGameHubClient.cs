using PillowFight.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PillowFight.Api.Hubs
{
    public interface IGameHubClient
    {
        Task ReceiveAction(string characterAction, MapPosition position, string resultDescription, IEnumerable<PlayerCharacter> characters);

        Task ReceiveActionOptions(int characterId, IEnumerable<string> options);

        Task ReceiveAvailableActions(int characterId, IEnumerable<string> actions);

        Task ReceiveAvailableRooms(IEnumerable<GameRoom> rooms);

        Task ReceiveJoinRoomRequest(GameRoom room, bool hasJoined);

        Task ReceiveNewRoomRequest(GameRoom room);
    }
}
