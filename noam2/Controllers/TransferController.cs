using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using noam2.Model;
using noam2.Service;

namespace noam2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransferController : Controller
    {
        private static IContactsService _contactsService = new ContactsService();
        public class TransferMessage
        {
            public string From { get; set; }
            public string To { get; set; }
            public string Content { get; set; }

        }

        // Post: Contact/{id}/messages
        [HttpPost("{id}/messages")]
        public ActionResult CreateMessage(string id, [Bind("From,To,Content")] TransferMessage transferMessage)
        {
            int isCreated = _contactsService.CreateMessage(transferMessage.From, id, transferMessage.Content);
            if (isCreated == 1)
            {
                return StatusCode(201);
            }
            return StatusCode(401);
        }
    } }

    
