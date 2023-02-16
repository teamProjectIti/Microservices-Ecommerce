using Microsoft.AspNetCore.SignalR;

namespace RealChatPrivate.api.SignalR.MessagePrivate
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string recipientId, string message)
        {
            await Clients.Client(recipientId).SendAsync("ReceiveMessage", message);
        }
    }
}
