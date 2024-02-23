using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace thema1.Hubs
{
    public class NotificationHub : Hub
    {
        public async Task SendNotification(string message)
        {
            // Αποστέλλει την ειδοποίηση σε όλους τους συνδεδεμένους clients
            await Clients.All.SendAsync("ReceiveNotification", message);
        }
    }
}
