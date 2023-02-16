
using Dto.SignalR;

namespace Repositery.Implemint.SignalR
{
    public interface IPrivateMessageRepository
    {
        Task SaveMessage(string senderId, string receiverId, string message);
        Task<List<MessageDto>> GetMessages(string userId);
    }
}
