using noam2.Controllers;
using noam2.Model;
using static noam2.Controllers.ContactController;

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
                       Messages = new List<Message>(){new Message(){Id=1,Content="hello itay",Sent=true, Created="10:10"}
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

        public int CreateContact(string connectedId,Contact contact)
        {
            if ( _users.Exists(u => u.Id == connectedId))
            {
                _users.FirstOrDefault(u => u.Id == connectedId).Contacts.Add(contact);
                return 1;
            }
            return 0;
            
        }

        public int UpdateContact(string connectContactId,string destId,string Name,string Server)
        {
            Contact c = _users.FirstOrDefault(u => u.Id == connectContactId).Contacts.FirstOrDefault(c => c.Id ==destId);
            c.Name = Name;
            c.Server = Server;
            return 0;

        }

        public int DeleteContact(string connectContactId, string contactId)
        {
            _users.FirstOrDefault(u => u.Id == connectContactId).Contacts.Remove(GetContact(connectContactId, contactId));
            return 0;
        }

        public int CreateMessage(string connectContactId, string destContactId,string content)
        {
            Chat chat=_chats.FirstOrDefault(c => (c.User1 == connectContactId && c.User2 == destContactId) || c.User2 == connectContactId && c.User1 == destContactId);
            int id = chat.Messages.Count() + 1;
            bool sent = chat.User1 == connectContactId;
            Message message = new() { Id = id, Sent = sent, Created = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffffff"), Content = content };
            chat.Messages.Add(message);
            
            return 0;
        }

        public Message GetMessageById(string connectContactId, string destContactId, int messageId)
        {
            Chat chat = _chats.FirstOrDefault(c => (c.User1 == connectContactId && c.User2 == destContactId) || c.User2 == connectContactId && c.User1 == destContactId);
            Message message= chat.Messages.FirstOrDefault(m => m.Id == messageId);
            if (chat.User1== connectContactId)
            {
                return message;
            }
            return new Message() { Id = messageId, Content = message.Content, Created = message.Created, Sent = false };
            }
            
        

        public List<Message> GetAllMessages(string connectContactId, string destContactId)
        {
        Chat chat = _chats.FirstOrDefault(c => (c.User1 == connectContactId && c.User2 == destContactId) || c.User2 == connectContactId && c.User1 == destContactId);
        if (chat.User1 == connectContactId)
            {
                return chat.Messages;
            }
            List<Message> messages =new List<Message>();
                foreach (Message message in chat.Messages) {
                    messages.Add(new Message() { Id = message.Id, Content = message.Content, Created = message.Created, Sent = !message.Sent });
                }
            return messages;
        }

        public int UpdateMessageById(string connectContactId, string destContactId, int messageId, string message)
        {
            Message m = _chats.FirstOrDefault(c => (c.User1 == connectContactId && c.User2 == destContactId) || c.User2 == connectContactId && c.User1 == destContactId).Messages.FirstOrDefault(m => m.Id == messageId);
            m.Content = message;
            return 0;

        }

        public int DeleteMessageById(string connectContactId, string destContactId, int messageId)
        {
            _chats.FirstOrDefault(c => (c.User1 == connectContactId && c.User2 == destContactId) || c.User2 == connectContactId && c.User1 == destContactId).Messages.Remove(GetMessageById(connectContactId, destContactId, messageId));
            return 0;
        }
    }
}
