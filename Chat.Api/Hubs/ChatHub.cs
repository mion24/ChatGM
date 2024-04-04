using Chat.Application.Contexts.ChatContext.DTO;
using Microsoft.AspNetCore.SignalR;

namespace Chat.Api.Hubs
{
    public class ChatHub : Hub
    {
        readonly List<ChatUser> ConnectedUsers = new();
        public override async Task OnConnectedAsync()
        {
            ChatUser chatUser = new(Context.UserIdentifier!, Context.UserIdentifier!, Context.ConnectionId);
            ConnectedUsers.Add(chatUser);    

            await Clients.All.SendAsync("ReceiveMesssage", $"O usuario {chatUser.Name} acaba de se conectar no ChatGM!");
            await base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            ConnectedUsers.Remove(ConnectedUsers.FirstOrDefault(x => x.ConnectionID == Context.ConnectionId)!);
            return base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(string message)
        {
            ChatMessage chatMessage = new(message, DateTime.Now, ConnectedUsers.First(x => x.ConnectionID.Equals(Context.ConnectionId)));
            await Clients.All.SendAsync("ReceiveMessage", chatMessage.Message);
        }
    }
}
