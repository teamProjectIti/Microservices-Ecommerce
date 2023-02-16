
namespace Dto.SignalR
{
    public class MessageDto
    {
        public long ReceiverId { get; set; }
        public long SenderId { get; set; }
        public string MessageText { get; set; }
    }
}
