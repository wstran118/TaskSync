using Microsoft.AspNetCore.SignalR;

namespace TaskSync.Hubs
{
    public class TaskHub : Hub
    {
        public async Task SendTaskUpdate(int taskId, string status)
        {
            await Clients.All.SendAsync("ReceiveTaskUpdate", taskId, status);
        }
    }
}