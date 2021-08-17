using Microsoft.AspNetCore.SignalR;
using PillowFight.Api.Models;
using PillowTactics.Game;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PillowFight.Api.Hubs
{
    //[Authorize]
    public class GameHub : Hub<IGameHubClient>
    {
        private const string userIdKey = "UserId";
        private const string groupIdKey = "GroupId";
        private const string lobbyGroup = "LobbyGroup";

        private static readonly List<int> lobbyClients = new();
        private static readonly Dictionary<Guid, GameRoom> rooms = new();
        private static readonly Dictionary<Guid, GameClient> games = new();

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
            //Context.Items[userIdKey] = Convert.ToInt32(Context.UserIdentifier);
            //lobbyClients.Add((int)Context.Items[userIdKey]);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await base.OnDisconnectedAsync(exception);

            // Remove player from lobby/room.
            lobbyClients.Remove((int)Context.Items[userIdKey]);
            await LeaveRoom();
        }

        #region Hub Actions
        public async Task SendAction(string characterAction, MapPosition mapPosition)
        {
            /*
             * Parameter 'resultDescription' will remain empty until game server is implemented.
             * Parameter 'characters' will remain null until game server is implemented.
             */
            await Clients.Group("").ReceiveAction(characterAction, mapPosition, string.Empty, null);
        }
        public async Task SendActionOptions(int characterId, string action)
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

        public async Task SendAvailableRooms()
        {
            await Clients.Caller.ReceiveAvailableRooms(rooms.Values);
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
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, lobbyGroup);

                // Add the player to the group associated with the room.
                await Groups.AddToGroupAsync(Context.ConnectionId, roomId);

                // Associate the room with this player's connection.
                Context.Items[groupIdKey] = room.Id;

                await Clients.Caller.ReceiveJoinRoomRequest(room, true);
            }
            catch
            {
                await Clients.Caller.ReceiveJoinRoomRequest(null, false);
            }
        }

        public async Task SendLeaveRoomRequest()
        {
            await LeaveRoom();
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
            lobbyClients.Remove((int)Context.Items[userIdKey]);
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, lobbyGroup);
            await Groups.AddToGroupAsync(Context.ConnectionId, room.Id.ToString());

            // Associate the room with this player's connection.
            Context.Items[groupIdKey] = room.Id;

            /*
             * Create a new game server hereabouts.
             */

            await Clients.Caller.ReceiveNewRoomRequest(room);
        }

        /*
         * Not emitting receive event for now...
         */
/*         public async Task SendUserInfo(int userId, IEnumerable<int> charactersIds)
        {
            Context.Items[userIdKey] = userId;
            await JoinLobby();
        } */

        /*
         * Remove this after presentation.
         * Current version of frontend will break without it.
         */
        public async Task SendUserInfo(int userId)
        {
            Context.Items[userIdKey] = userId;
            await JoinLobby();
        }
        #endregion

        #region Private Methods
        private async Task JoinLobby()
        {
            await LeaveRoom();
        }

        private async Task LeaveRoom()
        {
            if (Context.Items.ContainsKey(groupIdKey))
            {
                var roomId = (Guid)Context.Items[groupIdKey];
                var room = rooms[roomId];
                Context.Items.Remove(groupIdKey);
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomId.ToString());

                if (room.Player1Id == (int)Context.Items[userIdKey])
                {
                    room.Player1Id = null;
                }
                else if (room.Player2Id == (int)Context.Items[userIdKey])
                {
                    room.Player2Id = null;
                }

                if (room.Player1Id == null && room.Player2Id == null)
                {
                    rooms.Remove(roomId);
                }
            }

            if (!lobbyClients.Contains((int)Context.Items[userIdKey]))
            {
                lobbyClients.Add((int)Context.Items[userIdKey]);
                await Groups.AddToGroupAsync(Context.ConnectionId, lobbyGroup);
                await Clients.Group(lobbyGroup).ReceiveUserInfo((int)Context.Items[userIdKey]);
            }
        }
        #endregion
    }
}
