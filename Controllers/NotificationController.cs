using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using thema1.Hubs;
using thema1.Models;

public class NotificationController : Controller
{
    private readonly IHubContext<NotificationHub> _hubContext;

    public NotificationController(IHubContext<NotificationHub> hubContext)
    {
        _hubContext = hubContext;
    }

    [HttpPost]
    public IActionResult SendNotification(NotificationView model)
    {
        _hubContext.Clients.All.SendAsync("ReceiveNotification", model.Message);
        return Ok();
    }
}
