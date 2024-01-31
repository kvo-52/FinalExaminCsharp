using WebAppMessage.Model;

namespace WebAppMessage.Abstraction
{
    public interface IMessageRepository
    {
        public Guid SendMessage(string text, string senderName, string receiverName);
        public List<MessagesDB> GetAllMessages(string receiverName);

    }
}
