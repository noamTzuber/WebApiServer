using noam2.Controllers;
using noam2.Model;

namespace noam2.Service
{




    public class ContactsService : IContactsService
    {


        User yossi = new User() { 
            Id = "yossi", 
            Name = "yos", 
            Password = "123456789", 
            Server = "local1234", 
            Contacts = new List<Contact> { }
        };

        User noam = new User()
        {
            Id = "noam",
            Name = "nono",
            Password = "123456789",
            Server = "local1234",
            Contacts = new List<Contact> { }
        };



        public Contact noamTheContact = new Contact()
        {
            Id = "noam",
            Name = "nono",
            Server = "localHost 123",
            Last = "",
            Lastdate = ""
        };

        private static readonly List<User> _users = new List<User>() { };

        private static readonly List<Chat> _chats = new List<Chat>(){
            new Chat(){Id=1,
                       User1="yossi",
                       User2="noam" ,
                       Messages = new List<Message>(){new Message(){Id=1,Content="hello itay",Sent="yossi", Created="10:10"}
                       }
            }
        };

        public ContactsService()
        {
            _users.Add(yossi);
            _users.Add(noam);
            yossi.Contacts.Add(noamTheContact);

        }

        public List<Contact> GetAllContacts(string connectContactId)
        {
            return _users.FirstOrDefault(u => u.Id == connectContactId).Contacts;
        }

        public Contact GetContact(string connectContactId, string contactId)
        {
             return _users.FirstOrDefault(u => u.Id == connectContactId).Contacts.FirstOrDefault(c => c.Id == contactId);
        }

        public int CreateContact(string connectContactId, Contact contact)
        {
            _users.FirstOrDefault(u => u.Id == connectContactId).Contacts.Add(contact);
            return 0;
            
        }

        public int UpdateContact(string connectContactId, Contact contact)
        {
            Contact c = _users.FirstOrDefault(u => u.Id == connectContactId).Contacts.FirstOrDefault(c => c.Id == contact.Id);
            c = contact;
            return 0;

        }

        public int DeleteContact(string connectContactId, string contactId)
        {
            _users.FirstOrDefault(u => u.Id == connectContactId).Contacts.Remove(GetContact(connectContactId, contactId));
            return 0;
        }

        public int CreateMessage(string connectContactId, string destContactId, Message message)
        {
            _chats.FirstOrDefault(c => (c.User1 == connectContactId && c.User2 == destContactId) || c.User2 == connectContactId && c.User1 == destContactId).Messages.Add(message);
            return 0;
        }

        public Message GetMessageById(string connectContactId, string destContactId, int messageId)
        {
            return _chats.FirstOrDefault(c => (c.User1 == connectContactId && c.User2 == destContactId) || c.User2 == connectContactId && c.User1 == destContactId).Messages.FirstOrDefault(m => m.Id == messageId);
        }

        public List<Message> GetAllMessages(string connectContactId, string destContactId)
        {
            return _chats.FirstOrDefault(c => (c.User1 == connectContactId && c.User2 == destContactId) || c.User2 == connectContactId && c.User1 == destContactId).Messages;
        }

        public int UpdateMessageById(string connectContactId, string destContactId, int messageId, Message message)
        {
            Message m = _chats.FirstOrDefault(c => (c.User1 == connectContactId && c.User2 == destContactId) || c.User2 == connectContactId && c.User1 == destContactId).Messages.FirstOrDefault(m => m.Id == messageId);
            m = message;
            return 0;

        }

        public int DeleteMessageById(string connectContactId, string destContactId, int messageId)
        {
            _chats.FirstOrDefault(c => (c.User1 == connectContactId && c.User2 == destContactId) || c.User2 == connectContactId && c.User1 == destContactId).Messages.Remove(GetMessageById(connectContactId, destContactId, messageId));
            return 0;
        }
    }
}
