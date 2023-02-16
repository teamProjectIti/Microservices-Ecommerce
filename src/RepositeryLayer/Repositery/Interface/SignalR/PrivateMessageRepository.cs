using Data.Entities.Chat;
using Dto.SignalR;
using Microsoft.EntityFrameworkCore;
using Repositery.Implemint.SignalR;

namespace Repositery.Interface.SignalR
{
    public class PrivateMessageRepository //: IPrivateMessageRepository
    {
        //private readonly IHubContext<ChatHub> _hubContext;

        //public PrivateMessageRepository(IHubContext<ChatHub> hubContext)
        //{
        //    _hubContext = hubContext;
        //}

        //public Task SendMessage(string recipientId, string message)
        //{
        //    return _hubContext.Clients.User(recipientId).SendAsync("ReceiveMessage", message);
        //}
        private readonly DbContext _context;

        public PrivateMessageRepository(DbContext context)
        {
            _context = context;
        }

        //public async Task SaveMessage(string senderId, string receiverId, string message)
        //{
        //    // Save the message in the database
        //    _context.Messages.Add(new Message
        //    {
        //        SenderId = senderId,
        //        ReceiverId = receiverId,
        //        Message = message
        //    });
        //    await _context.SaveChangesAsync();
        //}

        //public async Task<List<MessageDto>> GetMessages(string userId)
        //{
        //    // Get the messages for the user
        //    return await _context.Messages
        //        .Where(m => m.SenderId == userId || m.ReceiverId == userId)
        //        .ToListAsync();
        //}

    }
}