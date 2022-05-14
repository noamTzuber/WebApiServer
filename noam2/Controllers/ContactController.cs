using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using noam2.Model;
using noam2.Service;

namespace noam2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : Controller
    {
        private static IContactsService _contactsService = new ContactsService();

        private string GetConnectedId()
        {
            return "yossi";

        }
        //************************************** Contacts ******************************************//

        // Post: Contact/
        [HttpPost]
        public ActionResult CreateContact([Bind("Id,Name,Server,Last,Lastdate")] Contact contact)
        {
            return Json(_contactsService.CreateContact(GetConnectedId(), contact));
        }

        // Get: Contact/
        [HttpGet]
        public ActionResult GetAllContacts()
        {
            return Json(_contactsService.GetAllContacts(GetConnectedId()));
        }

        // Get: Contact/{id}
        [HttpGet("{id}")]
        public ActionResult GetContact(string id)
        {
            return Json(_contactsService.GetContact(GetConnectedId(), id));
        }

        // Put: Contact/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateContact([Bind("Id,Name,Server,Last,Lastdate")] Contact contact)
        {
            return Json(_contactsService.UpdateContact(GetConnectedId(), contact));
        }

        // Delete: Contact/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteContact(string id)
        {
            return Json(_contactsService.DeleteContact(GetConnectedId(), id));
        }

        //************************************** Messages ******************************************//



        // Post: Contact/{id}/messages
        [HttpPost("{id}/messages")]
        public ActionResult CreateMessage(string id, [Bind("Id,Contaent,Sent,Created")] Message message)
        {
            return Json(_contactsService.CreateMessage(GetConnectedId(), id, message));
        }

        // Get: Contact/{id}/messages/{id2}
        [HttpGet("{id}/messages/{id2}")]
        public ActionResult GetMessageById(string id, int id2)
        {
            return Json(_contactsService.GetMessageById(GetConnectedId(), id, id2));
        }


        // Get: Contact/{id}/messages
        [HttpGet("{id}/messages")]
        public ActionResult GetAllMessages(string id)
        {
            return Json(_contactsService.GetAllMessages(GetConnectedId(), id));
        }


        [HttpPut("{id}/messages/{id2}")]
        public ActionResult UpdateMessageById(string id, int id2, [Bind("Id,Contaent,Sent,Created")] Message message)
        {
            return Json(_contactsService.UpdateMessageById(GetConnectedId(), id, id2, message));
        }

        [HttpDelete("{id}/messages/{id2}")]
        public ActionResult DeleteMessageById(string id, int id2)
        {
            return Json(_contactsService.DeleteMessageById(GetConnectedId(), id, id2));
        }

    }
}