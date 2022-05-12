using Microsoft.AspNetCore.Mvc;
using noam2.Model;
using noam2.Service;

namespace noam2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private static IContactsService _contactsService = new ContactsService();

        private readonly ILogger<ContactController> _logger;
        public ContactController(ILogger<ContactController> logger)
        {
            _logger = logger;
        }

        private string GetConnectedId()
        {
            return "yossi";
        }

        [HttpPost]
        public  void  CreateContact([Bind("Id,Name,Server,Password,Img, Contacts")] Contact contact)
        {
            _contactsService.CreateContact(GetConnectedId(), contact);
        }

        [HttpGet]
        public List<Contact> GetAllContacts( string id)
        {
           return _contactsService.GetAllContacts(GetConnectedId());

        }

        [HttpGet("{id}")]
        public Contact GetContact(string id)
        {
            return _contactsService.GetContact(GetConnectedId(), id);
        }
    }
}