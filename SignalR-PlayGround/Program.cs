using Microsoft.AspNetCore.SignalR;
using SignalR_PlayGround;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();
builder.Services.AddSingleton<IUserIdProvider, YourUserIdProvider>();
var app = builder.Build();

#region 动态的房间

// //可以动态生成
// Guid id = Guid.NewGuid();
//
// app.MapGet("/NewHub", (string token) =>
// {
//     //token验证
//     if (token != "shit")
//     {
//         return null;
//     }
//     
//     app.MapHub<TestHub>($"/{id}");
//     return id.ToString();
// });
//
// app.MapGet("/GetHub", (string token) =>
// {
//     //token验证
//     if (token != "shit")
//     {
//         return null;
//     }
//
//     return id.ToString();
// });

#endregion

app.MapHub<TestHub>("/TestHub");

app.Run();
