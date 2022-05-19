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
        private static IContactsService _contactsService;
        public TransferController(ContactsService contactsService)
        {
            _contactsService = contactsService;
        }
        public class TransferMessageObject
        {
            public string From { get; set; }
            public string To { get; set; }
            public string Content { get; set; }

        }

        // Post:transfer/
        [HttpPost]
        public ActionResult TransferMessage([Bind("From,To,Content")] TransferMessageObject transferMessageObject)
        {
            int isTransfered = _contactsService.TransferMessage(transferMessageObject.From, transferMessageObject.To, transferMessageObject.Content);
            if (isTransfered == 1)
            {
                return StatusCode(201);
            }
            return StatusCode(401);
        }
    } }

    
