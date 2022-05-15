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
            public string Last { get; set; } = "";
            public string Lastdate { get; set; } = "";
        }

        
        public class MessageData
        {
            public string ConnectedId { get; set; }
            public string Content { get; set; }
          
        }

        public class JsonResponse
        {

        }

        //************************************** Contacts ******************************************//

        // Post: Contact/
        [HttpPost]
        public ActionResult CreateContact([Bind("ConnectedId,Id,Name,Server,Last,Lastdate")] ContactCreate contactCreate)
        {
            return Json(_contactsService.CreateContact(contactCreate.ConnectedId,
                new Contact() { Id = contactCreate.Id, Name = contactCreate.Name, Server = contactCreate.Server, Last = contactCreate.Last, Lastdate = contactCreate.Lastdate }));
        }

        // Get: Contact/
        [HttpGet]
        public ActionResult GetAllContacts([Bind("ConnectedId")] ConnectedId connectedId)
        {
            return Json(_contactsService.GetAllContacts(connectedId.connectedId));
        }

        // Get: Contact/{id}
        [HttpGet("{id}")]
        public ActionResult GetContact(string id, [Bind("ConnectedId")] ConnectedId connectedId)
        {
            return Json(_contactsService.GetContact(connectedId.connectedId, id));
        }

        // Put: Contact/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateContact(string id,[Bind("ConnectedId,Name,Server")] ContactUpdateData contactUpdateData)
        {
            return Json(_contactsService.UpdateContact(contactUpdateData.ConnectedId,id,contactUpdateData.Name,contactUpdateData.Server));
        }

        // Delete: Contact/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteContact(string id, [Bind("ConnectedId")] ConnectedId connectedId)
        {
            return Json(_contactsService.DeleteContact(connectedId.connectedId, id));
        }

        //************************************** Messages ******************************************//



        // Post: Contact/{id}/messages
        [HttpPost("{id}/messages")]
        public ActionResult CreateMessage(string id, [Bind("ConnectedId,Content")] MessageData createMessage)
        {
            return Json(_contactsService.CreateMessage(createMessage.ConnectedId, id, createMessage.Content));
        }

        // Get: Contact/{id}/messages/{id2}
        [HttpGet("{id}/messages/{id2}")]
        public ActionResult GetMessageById(string id, int id2, [Bind("ConnectedId")] ConnectedId connectedId)
        {
            return Json(_contactsService.GetMessageById(connectedId.connectedId, id, id2));
        }


        // Get: Contact/{id}/messages
        [HttpGet("{id}/messages")]
        public ActionResult GetAllMessages([Bind("ConnectedId")] ConnectedId connectedId,string id)
        {
            return Json(_contactsService.GetAllMessages(connectedId.connectedId, id));
        }


        [HttpPut("{id}/messages/{id2}")]
        public ActionResult UpdateMessageById(string id, int id2, [Bind("ConnectedId,Content")] MessageData message)
        {
            return Json(_contactsService.UpdateMessageById(message.ConnectedId, id, id2, message.Content));
        }

        [HttpDelete("{id}/messages/{id2}")]
        public ActionResult DeleteMessageById([Bind("ConnectedId")] ConnectedId connectedId,string id, int id2)
        {
            return Json(_contactsService.DeleteMessageById(connectedId.connectedId, id, id2));
        }

    }
}