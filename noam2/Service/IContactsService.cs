using noam2.Model;

namespace noam2.Controllers
{
    public interface IContactsService
    {
        //Contacts
        public List<Contact> GetAllContacts();
        public Contact GetContact(string id);
        public int CreateContact(Contact contact);
        public int UpdateContact(Contact contact);
        public int DeleteContact(string id);

        // Messages
        public int CreateMessage(string contactId1, string contactId2, Message message);
        public Message GetMessageByID(string contactId1, string contactId2, int messageId);
        public List<Message> GetAllMessagesByID(string contactId1, string contactId2);


        public int UpdateMessageByChatId(string contactId1, string contactId2, int messageId, Message message);
        public int DeleteMessageByChatId(string contactId1, string contactId2, int messageId);

    }
}
