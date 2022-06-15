using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using noam2.Model;
using noam2.Service;

namespace noam2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class contactsController : Controller
    {
        private static IContactsService _contactsService;
        public contactsController(ContactsService contactsService)
        {
            _contactsService = contactsService;
        }
   
        //************************************** Contacts *****************************in*************//

        // Post: Contact/
        [HttpPost]
        public ActionResult CreateContact(string connectedId ,[Bind("Id,Name,Server")] ContactCreate contactCreate)
        {
            Contact contact = new Contact() { Id = contactCreate.Id, Name = contactCreate.Name, Server = contactCreate.Server, Last = "", Lastdate = "" };
            int isCreates=_contactsService.CreateContact(connectedId, contact);
            if (isCreates == 1)
            {
                return StatusCode(201);
            }
            return StatusCode(401);

        }

        // Get: Contact?connectedId={connectedId}
        [HttpGet]
        public ActionResult GetAllContacts(string connectedId)
        {
            
            List<Contact> contacts=_contactsService.GetAllContacts(connectedId);
            if(contacts == null)
            {
                return StatusCode(401);
            }
            return Json(contacts);
        }

        // Get: Contact/{id}?connectedId={connectedId}
        [HttpGet("{id}")]
        public ActionResult GetContact(string id, string connectedId)
        {
            Contact contact = _contactsService.GetContact(connectedId, id);
            if (contact == null)
            {
                return NotFound();
            }
            return Json(contact);
        }

        // Put: Contact/{id}?connectedId={connectedId}
        [HttpPut("{id}")]
        public ActionResult UpdateContact(string id,string connectedId,[Bind("Name,Server")] ContactUpdateData contactUpdateData)
        {
            int isUpdate=_contactsService.UpdateContact(connectedId, id, contactUpdateData.Name, contactUpdateData.Server);
           if (isUpdate == 1)
            {
                return NoContent();
            }
            return StatusCode(401);
        }

        // Delete: Contact/{id}?connectedId={connectedId}
        [HttpDelete("{id}")]
        public ActionResult DeleteContact(string id,string connectedId)
        {
            int isDelete= _contactsService.DeleteContact(connectedId, id);
            if (isDelete == 1)
            {
                return StatusCode(204);
            }
            return StatusCode(401);
        }

        //************************************** Messages ******************************************//



        // Post: Contact/{id}/messages?connectedId={connectedId}
        [HttpPost("{id}/messages")]
        public ActionResult CreateMessage(string id,string connectedId, [Bind("Content")] MessageData createMessage)
        {
            int isCreated= _contactsService.CreateMessage(connectedId, id, createMessage.Content);
            if (isCreated == 1)
            {
                return StatusCode(201);
            }
            return StatusCode(401);
        }

        // Get: Contact/{id}/messages/{id2}?connectedId={connectedId}
        [HttpGet("{id}/messages/{id2}")]
        public ActionResult GetMessageById(string id, int id2, string connectedId)
        {
            Message message=_contactsService.GetMessageById(connectedId, id, id2);
            if (message != null)
            {
                return Json(message);
            }
            return NotFound();
        }


        // Get: Contact/{id}/messages?connectedId={connectedId}
        [HttpGet("{id}/messages")]
        public ActionResult GetAllMessages(string id, string connectedId)
        {
            List<Message> messages=_contactsService.GetAllMessages(connectedId, id);
            if (messages != null)
            {
                return Json(messages);
            }
            return StatusCode(401);
        }


        [HttpPut("{id}/messages/{id2}")]
        public ActionResult UpdateMessageById(string id, int id2,string connectedId, [Bind("Content")] MessageData message)
        {
            int isUpdate=_contactsService.UpdateMessageById(connectedId, id, id2, message.Content);
            if (isUpdate == 1)
            {
                return StatusCode(204);
            }
            return NotFound();
        }

        [HttpDelete("{id}/messages/{id2}")]
        public ActionResult DeleteMessageById(string connectedId,string id, int id2)
        {
            int isDelete= _contactsService.DeleteMessageById(connectedId, id, id2);
            if (isDelete == 1)
            {
                return NoContent();
            }
            return StatusCode(401);
        }


        //************************************************Our Functions*****************************************

        // Get: Contact/User?connectedId={connectedId}
        [HttpGet("User")]
        public ActionResult GetUser(string connectedId)
        {
            User user = _contactsService.GetUser(connectedId);
            if (user != null)
            {
                return Json(user);
            }
            return NotFound();
        }

        // Get: contacts/AllUsers
        [HttpGet("AllUsers")]
        public ActionResult GetAllUsers()
        {
            var res = Json(_contactsService.GetAllUsers());
            return res;
            
        }



        // Get: Contact/User?connectedId={connectedId}
        [HttpGet("Chats")]
        public ActionResult GetChats(string connectedId)
        {
            return Json( _contactsService.GetChats(connectedId));
           
        }


        // Post: contacts/User
        [HttpPost("User")]
        public ActionResult CreateUser([Bind("Id,Name,Password, Server, Contacts")] User user)
        {
            int isCreates = _contactsService.CreateUser(user);
            if (isCreates == 1)
            {
                return NoContent();
            }
            return StatusCode(401);
        }
    }
}