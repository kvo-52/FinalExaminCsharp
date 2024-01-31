namespace WebAppMessage.Model
{
    public class MessagesDB
    {
        public Guid Id { get; set; }
        public string SenderName { get; set; }
        public string ReceiverName { get; set; }
        public string Text { get; set; }
        public bool IsReceived { get; set; }
    }
}
