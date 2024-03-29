﻿using WebAppMessage.Abstraction;
using WebAppMessage.Model;

namespace WebAppMessage.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        public Guid SendMessage(string text, string senderName, string receiverName)
        {
            using (var context = new MessagesContext())
            {
                if (senderName != null && receiverName != null)
                {
                    var id = Guid.NewGuid();
                    var message = new MessagesDB()
                    {
                        Id = id,
                        SenderName = senderName,
                        ReceiverName = receiverName,
                        Text = text,
                        IsReceived = false
                    };
                    context.Messages.Add(message);
                    context.SaveChanges();
                    return id;
                }
            }

            throw new ArgumentException("There are no such registered users in the system");
        }

        public List<MessagesDB> GetAllMessages(string receiverName)
        {
            using (var context = new MessagesContext())
            {
                var messages = context.Messages
                    .Where(message => message.ReceiverName == receiverName && message.IsReceived == false)
                    .ToList();
                foreach (var message in messages)
                {
                    message.IsReceived = true;
                    context.SaveChanges();
                }

                return messages;
            }
        }
    }
}
