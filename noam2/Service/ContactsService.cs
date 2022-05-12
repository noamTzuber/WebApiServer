using noam2.Controllers;
using noam2.Model;

namespace noam2.Service
{

  

      
    public class ContactsService : IContactsService
    {
        private static readonly List<Chat> _chats = new List<Chat>(){
            new Chat(){Id=1,
                       Contacts=new List<string>(){"noam","itay" },
                       Messages = new List<Message>(){new Message(){Id=1,Content="hello",Sender="noam",Type="text"}
                       }
        }};

        private static readonly List<Contact> _contacts = new List<Contact>()
        {
        };
        private Contact yossi = new()
        {
            Id = "yossi",
            Name = "yo",
            Server = "localHost 123",
            Password = "12345678",
            Img = "aaa",
            Chats = new List<int>() { }
        };
        private Contact itay = new Contact()
        {
            Id = "itay",
            Name = "iti",
            Server = "localHost 123",
            Password = "12345678",
            Img = "aaa",
            Chats = new List<int>() { 1 }
        };

     

        public int CreateContact(Contact contact)
        {
            throw new NotImplementedException();
        }

        public int CreateMessage(string contactId1, string contactId2, Message message)
        {
            throw new NotImplementedException();
        }

        public int DeleteContact(string id)
        {
            throw new NotImplementedException();
        }

        public int DeleteMessageByChatId(string contactId1, string contactId2, int messageId)
        {
            throw new NotImplementedException();
        }

        public List<Contact> GetAllContacts()
        {
            throw new NotImplementedException();
        }

        public List<Message> GetAllMessagesByID(string contactId1, string contactId2)
        {
            throw new NotImplementedException();
        }

        public Contact GetContact(string id)
        {
            throw new NotImplementedException();
        }

        public Message GetMessageByID(string contactId1, string contactId2, int messageId)
        {
            throw new NotImplementedException();
        }

        public int UpdateContact(Contact contact)
        {
            throw new NotImplementedException();
        }

        public int UpdateMessageByChatId(string contactId1, string contactId2, int messageId, Message message)
        {
            throw new NotImplementedException();
        }
    }
}
