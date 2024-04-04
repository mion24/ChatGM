using Chat.Api.Extensions;
using Chat.Api.Hubs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();
builder.AddConfiguration();
builder.AddDatabase();
builder.AddJwtAuthentication();


var app = builder.Build();
app.MapHub<ChatHub>("/chat-hub").RequireAuthorization();

app.Run();
