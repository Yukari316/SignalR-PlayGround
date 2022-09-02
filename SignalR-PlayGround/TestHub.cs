using System.Security.Cryptography;
using Microsoft.AspNetCore.SignalR;

namespace SignalR_PlayGround
{
    public class TestHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            //此id仅为链接id
            string id = Context.ConnectionId;
            Console.WriteLine($"[Join] {id}");
            await Clients.All.SendAsync("Join", $"[{id}] join");
        }

        public Task SendMessage(string message)
        {
            Console.WriteLine($"[Message][{Context.ConnectionId}] {message}");
            return Clients.Others.SendAsync("Massage", Context.ConnectionId, message);
        }
    }
}
