using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Chatty.Api.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string message, string src, string dst)
        {
            await Clients.All.SendAsync("ReceiveMessage", message, src, dst);
        }


        public async Task AddContact(string contactId, string name, string server, string src, string dst)
        {
            await Clients.All.SendAsync("ContactAdded", contactId, name, server, src, dst);
        }
    }
}