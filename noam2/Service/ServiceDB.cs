using Microsoft.EntityFrameworkCore;
using noam2.Controllers;
using noam2.Model;

namespace noam2.Service
{
    public class ServiceDB : IContactsService
    {
        private static DbContext DbContext;

        public void setDB(DbContext db)
        {
            DbContext = db;
        }
        public int CreateContact(string connectedId, Contact contact)
        {
            DbContext.Add<ContactExtended>(new ContactExtended(contact.Id, );
            return 1;
        }

        public int CreateMessage(string connectContactId, string destContactId, string content)
        {
            throw new NotImplementedException();
        }

        public int CreateUser(User user)
        {
            _ = DbContext.Add(new UserExtended(user.Id, user.Name, user.Password, user.Server));
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

        public List<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public List<Chat> GetChats(string id)
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

        public User GetUser(string id)
        {
            throw new NotImplementedException();
        }

        public User GetUserById(string id)
        {
            throw new NotImplementedException();
        }

        public int InviteContact(string from, string to, string server)
        {
            throw new NotImplementedException();
        }

        public int SetToken(TokenToId tokenToId)
        {
            throw new NotImplementedException();
        }

        public int TransferMessage(string from, string to, string content)
        {
            throw new NotImplementedException();
        }

        public int UpdateContact(string connectContactId, string destId, string Name, string Server)
        {
            throw new NotImplementedException();
        }

        public int UpdateMessageById(string connectContactId, string destContactId, int messageId, string message)
        {
            throw new NotImplementedException();
        }
    }
}
