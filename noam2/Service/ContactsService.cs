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
                       User2="noamTheContact" ,
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

        public List<Contact> GetAllContacts(string connectId)
        {
            throw new NotImplementedException();
        }

        public Contact GetContact(string connectContactId, string contactId)
        {
            throw new NotImplementedException();
        }

        public int CreateContact(string connectContactId, Contact contact)
        {
            throw new NotImplementedException();
        }

        public int UpdateContact(string connectContactId, Contact contact)
        {
            throw new NotImplementedException();
        }

        public int DeleteContact(string connectContactId, string contactId)
        {
            throw new NotImplementedException();
        }

        public int CreateMessage(string connectContactId, string destContactId, Message message)
        {
            throw new NotImplementedException();
        }

        public Message GetMessageById(string connectContactId, string destContactId, int messageId)
        {
            throw new NotImplementedException();
        }

        public List<Message> GetAllMessages(string connectContactId, string destContactId)
        {
            throw new NotImplementedException();
        }

        public int UpdateMessageById(string connectContactId, string destContactId, int messageId, Message message)
        {
            throw new NotImplementedException();
        }

        public int DeleteMessageById(string connectContactId, string destContactId, int messageId)
        {
            throw new NotImplementedException();
        }
    }
}
