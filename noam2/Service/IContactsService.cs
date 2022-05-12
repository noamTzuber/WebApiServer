using noam2.Model;

namespace noam2.Controllers
{
    public interface IContactsService
    {
        //Contacts
        public List<Contact> GetAllContacts(string connectId);
        public Contact GetContact(string connectContactId, string contactId);
        public int CreateContact(string connectContactId, Contact contact);
        public int UpdateContact(string connectContactId, Contact contact);
        public int DeleteContact(string connectContactId, string contactId);

        // Messages
        public int CreateMessage(string connectContactId, string destContactId, Message message);
        public Message GetMessageById(string connectContactId, string destContactId, int messageId);
        public List<Message> GetAllMessages(string connectContactId, string destContactId);
        public int UpdateMessageById(string connectContactId,  string destContactId, int messageId, Message message);
        public int DeleteMessageById(string connectContactId, string destContactId, int messageId);

    }
}
