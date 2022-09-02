using Microsoft.AspNetCore.SignalR;
using SignalR_PlayGround;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();
builder.Services.AddSingleton<IUserIdProvider, YourUserIdProvider>();
var app = builder.Build();

#region ��̬�ķ���

// //���Զ�̬����
// Guid id = Guid.NewGuid();
//
// app.MapGet("/NewHub", (string token) =>
// {
//     //token��֤
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
//     //token��֤
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
