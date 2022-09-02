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
            Console.WriteLine( $"[Join] {id}" );
            await Clients.All.SendAsync( "Join", $"[{id}] join" );
            await Task.Delay( TimeSpan.FromSeconds( 10 ) );
            await SendMessage( "HOLY SHIT!!!" );
        }

        public Task SendMessage( string message )
        {
            Console.WriteLine( $"[Message][{Context.ConnectionId}] {message}" );
            return Clients.User( "myid123" ).SendAsync( "Message", Context.ConnectionId, message );
        }
    }

    public class YourUserIdProvider : IUserIdProvider
    {
        public virtual string GetUserId( HubConnectionContext connection )
        {
            var userid = connection.GetHttpContext()?.Request.Headers[ "test" ].ToString() ?? "";
            Console.WriteLine( "GET USERID:" + userid );
            return userid;
            // 你如何获取 UserId，可以通过 connection.User 获取 JWT 授权的用户
        }
    }
}
