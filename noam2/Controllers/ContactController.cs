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

        public class ConnectedId
        {
           public string connectedId { get; set; }
        }

        public class ContactUpdateData
        {
            public string ConnectedId { get; set; }

            public string Name { get; set; }
            public string Server { get; set; }

        }
        public class ContactCreate
        {
            public string ConnectedId { get; set; }
            public string Id { get; set; }
            public string Name { get; set; }
            public string Server { get; set; }

        }

        
        public class MessageData
        {
            public string ConnectedId { get; set; }
            public string Content { get; set; }
          
        }

        private string whoConnected()
        {
            return "yossi";
        }



        //************************************** Contacts ******************************************//

        // Post: Contact/
        [HttpPost]
        public ActionResult CreateContact([Bind("ConnectedId,Id,Name,Server")] ContactCreate contactCreate)
        {
            Contact contact = new Contact() { Id = contactCreate.Id, Name = contactCreate.Name, Server = contactCreate.Server, Last = "", Lastdate = "" };
            int isCreates=_contactsService.CreateContact(contactCreate.ConnectedId, contact);
            if (isCreates == 1)
            {
                return NoContent();
            }
            return StatusCode(401);

        }

        // Get: Contact/
        [HttpGet]
        public ActionResult GetAllContacts()
        {
            
            List<Contact> contacts=_contactsService.GetAllContacts(whoConnected());
            if(contacts == null)
            {
                return StatusCode(401);
            }
            return Json(contacts);
        }

        // Get: Contact/{id}
        [HttpGet("{id}")]
        public ActionResult GetContact(string id)
        {
            Contact contact = _contactsService.GetContact(whoConnected(), id);
            if (contact == null)
            {
                return NotFound();
            }
            return Json(contact);
        }

        // Put: Contact/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateContact(string id,[Bind("ConnectedId,Name,Server")] ContactUpdateData contactUpdateData)
        {
            int isUpdate=_contactsService.UpdateContact(contactUpdateData.ConnectedId, id, contactUpdateData.Name, contactUpdateData.Server);
           if (isUpdate == 1)
            {
                return NoContent();
            }
            return StatusCode(401);
        }

        // Delete: Contact/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteContact(string id, [Bind("ConnectedId")] ConnectedId connectedId)
        {
            int isDelete= _contactsService.DeleteContact(connectedId.connectedId, id);
            if (isDelete == 1)
            {
                return NoContent();
            }
            return StatusCode(401);
        }

        //************************************** Messages ******************************************//



        // Post: Contact/{id}/messages
        [HttpPost("{id}/messages")]
        public ActionResult CreateMessage(string id, [Bind("ConnectedId,Content")] MessageData createMessage)
        {
            int isCreated= _contactsService.CreateMessage(createMessage.ConnectedId, id, createMessage.Content);
            if (isCreated == 1)
            {
                return StatusCode(201);
            }
            return StatusCode(401);
        }

        // Get: Contact/{id}/messages/{id2}
        [HttpGet("{id}/messages/{id2}")]
        public ActionResult GetMessageById(string id, int id2)
        {
            Message message=_contactsService.GetMessageById(whoConnected(), id, id2);
            if (message != null)
            {
                return Json(message);
            }
            return NotFound();
        }


        // Get: Contact/{id}/messages
        [HttpGet("{id}/messages")]
        public ActionResult GetAllMessages(string id)
        {
            List<Message> messages=_contactsService.GetAllMessages(whoConnected(), id);
            if (messages != null)
            {
                return Json(messages);
            }
            return StatusCode(401);
        }


        [HttpPut("{id}/messages/{id2}")]
        public ActionResult UpdateMessageById(string id, int id2, [Bind("ConnectedId,Content")] MessageData message)
        {
            int isUpdate=_contactsService.UpdateMessageById(message.ConnectedId, id, id2, message.Content);
            if (isUpdate == 1)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("{id}/messages/{id2}")]
        public ActionResult DeleteMessageById([Bind("ConnectedId")] ConnectedId connectedId,string id, int id2)
        {
            int isDelete= _contactsService.DeleteMessageById(connectedId.connectedId, id, id2);
            if (isDelete == 1)
            {
                return NoContent();
            }
            return StatusCode(401);
        }

    }
}