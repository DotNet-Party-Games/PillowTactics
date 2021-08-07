using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using PillowFight.Api.Models;
using PillowFight.Repositories.Enumerations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PillowFight.Api.Hubs
{
    public class GameHub : Hub<IGameHubClient>
    {
        public async Task SendAction(CharacterAction characterAction)
        {
            /*
             * Parameter 'characterAction' will remain null until game server is implemented.
             * Parameter 'resultDescription' will remain empty until game server is implemented.
             * Parameter 'characters' will remain null until game server is implemented.
             */
            await Clients.All.ReceiveAction(null, string.Empty, null);
        }

        public async Task SendActionOptions(int characterId, ActionTypeEnum action)
        {
            /*
             * Parameter 'options' will remain null until game server implemented.
             */
            await Clients.Caller.ReceiveActionOptions(characterId, null);
        }

        public async Task SendAvailableActions(int characterId)
        {
            /*
             * Parameter 'actions' will remain null until game server implemented.
             */ 
            await Clients.Caller.ReceiveAvailableActions(characterId, null);
        }
    }
}
