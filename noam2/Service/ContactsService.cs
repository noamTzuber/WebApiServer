using noam2.Model;

namespace noam2.Controllers
{
    public class ContactsService : IContactsService
    {
        public int CreateContact(string connectContactId, Contact contact)
        {
            throw new NotImplementedException();
        }

        public int CreateMessage(string connectContactId, string destContactId, Message message)
        {
            throw new NotImplementedException();
        }

        public int DeleteContact(string connectContactId, string contactId)
        {
            throw new NotImplementedException();
        }

        public int DeleteMessageById(string connectContactId, string destContactId, int messageId)
        {
            throw new NotImplementedException();
        }

        public List<Contact> GetAllContacts(string connectId)
        {
            throw new NotImplementedException();
        }

        public List<Message> GetAllMessages(string connectContactId, string destContactId)
        {
            throw new NotImplementedException();
        }

        public Contact GetContact(string connectContactId, string contactId)
        {
            throw new NotImplementedException();
        }

        public Message GetMessageById(string connectContactId, string destContactId, int messageId)
        {
            throw new NotImplementedException();
        }

        public int UpdateContact(string connectContactId, Contact contact)
        {
            throw new NotImplementedException();
        }

        public int UpdateMessageById(string connectContactId, string destContactId, int messageId, Message message)
        {
            throw new NotImplementedException();
        }
    }
}
