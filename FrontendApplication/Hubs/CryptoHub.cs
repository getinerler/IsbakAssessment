using FrontendApplication.Dtos;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FrontendApplication.Hubs
{
    public class CryptoHub : Hub
    {
        public string GetConnectionId()
        {
            return Context.ConnectionId;
        }

        public override Task OnConnectedAsync()
        {
            UserHandler.ConnectedIds.Add(Context.ConnectionId);
            Clients.Client(Context.ConnectionId).SendAsync("ConnectionId", Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            UserHandler.ConnectedIds.Remove(Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }

        public async Task NewCryptoData(List<CryptoSignalRModel> list)
        {
            await Clients.All.SendAsync("GetCryptoData", list);
        }

        public static class UserHandler
        {
            public static HashSet<string> ConnectedIds = new HashSet<string>();
        }
    }
}
