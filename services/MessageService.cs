using MVC_Project.DatabaseActions.DatabaseContent;
using System;
using System.Collections.Generic;
using System.Linq;

public interface IMessageService
{
    void SendMessage(int senderId, int receiverId, string content);
    List<Message> GetInboxMessages(int userId);
    List<Message> GetSentMessages(int userId);
}

public class MessageService : IMessageService
{
    private readonly AppDbContext _dbContext;

    public MessageService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void SendMessage(int senderId, int receiverId, string content)
    {
        var message = new Message
        {
            SenderId = senderId,
            ReceiverId = receiverId,
            Content = content,
            Timestamp = DateTime.Now
        };

        _dbContext.Messages.Add(message);
        _dbContext.SaveChanges();
    }

    public List<Message> GetInboxMessages(int userId)
    {
        return _dbContext.Messages.Where(m => m.ReceiverId == userId).ToList();
    }

    public List<Message> GetSentMessages(int userId)
    {
        return _dbContext.Messages.Where(m => m.SenderId == userId).ToList();
    }
}
