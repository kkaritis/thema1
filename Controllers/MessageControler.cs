using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

public class MessageController : Controller
{
    private readonly IMessageService _messageService;
    private readonly IUserService _userService;

    public MessageController(IMessageService messageService, IUserService userService)
    {
        _messageService = messageService;
        _userService = userService;
    }

    // Εμφάνιση της σελίδας σύνταξης μηνύματος
    public IActionResult Compose()
    {
        return View();
    }

    // Αποστολή μηνύματος
    [HttpPost]
    public IActionResult Compose(Message model)
    {
        if (ModelState.IsValid)
        {
            var message = new Message
            {
                SenderId = User.Identity.Name,
                ReceiverId = model.ReceiverId,
                Content = model.Content,
                Timestamp = DateTime.Now
            };
            // Καλείτε τη μέθοδο SendMessage του _messageService με τις κατάλληλες παραμέτρους
            _messageService.SendMessage(senderId, receiverId, content);

            return RedirectToAction(nameof(Inbox));
        }
        return View(model);
    }

    // Εμφάνιση εισερχόμενων μηνυμάτων
    public IActionResult Inbox()
    {
        var userId = User.Identity.Name;
        var inboxMessages = _messageService.GetInboxMessages(userId);
        return View(inboxMessages);
    }

    // Εμφάνιση απεσταλμένων μηνυμάτων
    public IActionResult Sent()
    {
        var userId = User.Identity.Name;
        var sentMessages = _messageService.GetSentMessages(userId);
        return View(sentMessages);
    }
}
