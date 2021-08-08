using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using PillowFight.Api.Models;
using PillowFight.Repositories.Enumerations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PillowFight.Api.Hubs
{
    [Authorize]
    public class GameHub : Hub<IGameHubClient>
    {
        private const string userIdKey = "UserId";
        private const string groupIdKey = "GroupId";

        private List<int> lobbyClients = new List<int>();
        private Dictionary<Guid, GameRoom> rooms = new Dictionary<Guid, GameRoom>();

        public override async Task OnConnectedAsync()
        {
            Context.Items[userIdKey] = Convert.ToInt32(Context.UserIdentifier);
            lobbyClients.Add((int)Context.Items[userIdKey]);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            lobbyClients.Remove((int)Context.Items[userIdKey]);
            await base.OnDisconnectedAsync(exception);
        }

        public async Task SendAction(CharacterAction characterAction)
        {
            /*
             * Parameter 'characterAction' will remain null until game server is implemented.
             * Parameter 'resultDescription' will remain empty until game server is implemented.
             * Parameter 'characters' will remain null until game server is implemented.
             */
            await Clients.Group("").ReceiveAction(null, string.Empty, null);
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

        public async Task SendJoinRoomRequest(string roomId)
        {
            try
            {
                // Get the requested room.
                var room = rooms[Guid.Parse(roomId)];

                // Attempt to join room.
                if (room.Player1Id == null)
                {
                    room.Player1Id = (int)Context.Items[userIdKey];
                }
                else if (room.Player2Id == null)
                {
                    room.Player2Id = (int)Context.Items[userIdKey];
                }
                else
                {
                    await Clients.Caller.ReceiveJoinRoomRequest(null, false);
                }

                // Remove player from lobby.
                lobbyClients.Remove((int)Context.Items[userIdKey]);

                // Add the player to the group associated with the room.
                await Groups.AddToGroupAsync(Context.ConnectionId, roomId);
            }
            catch
            {
                await Clients.Caller.ReceiveJoinRoomRequest(null, false);
            }
        }

        public async Task SendNewRoomRequest(string roomName)
        {
            // Remove player from lobby.
            lobbyClients.Remove((int)Context.Items[userIdKey]);

            // Create a new game room.
            var room = new GameRoom()
            {
                Id = Guid.NewGuid(),
                Name = roomName,
                Player1Id = (int)Context.Items[userIdKey]
            };

            // Track the room.
            rooms[room.Id] = room;

            // Create a new group associated with the room id and add the player.
            await Groups.AddToGroupAsync(Context.ConnectionId, room.Id.ToString());

            // Associate the room with this player's connection.
            Context.Items[groupIdKey] = room.Id;

            /*
             * Create a new game server hereabouts.
             */

            await Clients.Caller.ReceiveNewRoomRequest(room);
        }
    }
}
