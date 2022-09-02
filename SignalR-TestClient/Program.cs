// See https://aka.ms/new-console-template for more information

using Microsoft.AspNetCore.SignalR.Client;

Console.WriteLine("HolyShit");

Console.WriteLine("build conn");
HubConnection connection = new HubConnectionBuilder()
    .WithUrl("http://127.0.0.1:5000/TestHub")
    .Build();

Console.WriteLine("start conn");
await connection.StartAsync();

connection.On<string, string>("Massage", (user, msg) =>
{
    Console.WriteLine($"new msg:[{user}] {msg}");
});

connection.On<string>("Join", user =>
{
    Console.WriteLine($"new user join: {user}");
});

while (true)
{
    string? msgSend = Console.ReadLine();
    await connection.InvokeAsync("SendMessage", msgSend);
}