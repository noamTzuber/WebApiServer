using Chatty.Api.Hubs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using noam2.Model;
using noam2.Service;

namespace noam2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransferController : Controller
    {
        private static IContactsService _contactsService;
        IHubContext<ChatHub> hub;
        public TransferController(ContactsService contactsService, IHubContext<ChatHub> hub)
        {
            _contactsService = contactsService;
            this.hub = hub;
        }

        public class TransferMessageObject
        {
            public string From { get; set; }
            public string To { get; set; }
            public string Content { get; set; }

        }

        // Post:transfer/
        [HttpPost]
        public async Task<IActionResult> TransferMessage([Bind("From,To,Content")] TransferMessageObject transferMessageObject)
        {
            int isTransfered = _contactsService.TransferMessage(transferMessageObject.From, transferMessageObject.To, transferMessageObject.Content);
            if (isTransfered == 1)
            {
                await hub.Clients.All.SendAsync("ReceiveMessage", transferMessageObject.Content, transferMessageObject.From, transferMessageObject.To);

                return StatusCode(201);
            }
            return StatusCode(401);
        }
    } }

    
