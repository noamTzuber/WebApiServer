using noam2.Controllers;
using noam2.Model;

namespace noam2.Service
{

  

      
    public class ContactsService : IContactsService
    {
        public Contact yossi = new Contact()
        {
            Id = "yossi",
            Name = "yo",
            Server = "localHost 123",
            Password = "12345678",
            Img = "aaa",
            Contacts = new List<Contact>() { }
        };
        public Contact itay = new Contact()
        {
            Id = "itay",
            Name = "iti",
            Server = "localHost 123",
            Password = "12345678",
            Img = "aaa",
            Contacts = new List<Contact>() { }
        };

        public Contact noam = new Contact()
        {
            Id = "noam",
            Name = "nono",
            Server = "localHost 123",
            Password = "12345678",
            Img = "aaa",
            Contacts = new List<Contact>() {}
        };

        private static readonly List<Contact> _contacts = new List<Contact>(){};


        private static readonly List<Chat> _chats = new List<Chat>(){
            new Chat(){Id=1,
                       Contacts=new List<string>(){"yossi","itay" },
                       Messages = new List<Message>(){new Message(){Id=1,Content="hello itay",Sender="yossi",Type="text", Date="10:10"}
                       }        
            },
             new Chat(){Id=2,
                       Contacts=new List<string>(){"yossi","noam" },
                       Messages = new List<Message>(){new Message(){Id=2,Content="hello yossi",Sender="noam",Type="text", Date="12:50"}
                       }
            }
        };
        
           public ContactsService()
        {

            _contacts.Add(yossi);
            _contacts.Add(noam);
            _contacts.Add(itay);


            yossi.Contacts.Add(itay);
            yossi.Contacts.Add(noam);
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
