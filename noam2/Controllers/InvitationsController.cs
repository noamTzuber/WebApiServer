using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using noam2.Model;
using noam2.Service;

namespace noam2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvitationsController : Controller
    {
        private static IContactsService _contactsService = new ContactsService();
        public class InvitationsMessage
        {
            public string From { get; set; }
            public string To { get; set; }
            public string Server { get; set; }

        }

        
        [HttpPost]
        public ActionResult InviteContact( [Bind("From,To,Server")] InvitationsMessage invitationsMessage)
        {
            int isInvited = _contactsService.InviteContact(invitationsMessage.From, invitationsMessage.To, invitationsMessage.Server);
            if (isInvited == 1)
            {
                return StatusCode(201);
            }
            return StatusCode(401);
        }
    } 
}

