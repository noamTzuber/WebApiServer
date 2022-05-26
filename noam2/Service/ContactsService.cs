using Microsoft.AspNetCore.Mvc;
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
            Server = "localhost:1234", 
            Contacts = new List<Contact> { }
        };

        User noam = new User()
        {
            Id = "noam",
            Name = "nono",
            Password = "123456789",
            Server = "localhost:1234",
            Contacts = new List<Contact> { }
        };

        User david = new User()
        {
            Id = "david",
            Name = "david",
            Password = "123456789",
            Server = "localhost:1234",
            Contacts = new List<Contact> { }
        };
        User dvir = new User()
        {
            Id = "dvir",
            Name = "dvir",
            Password = "123456789",
            Server = "localhost:1234",
            Contacts = new List<Contact> { }
        };

        User dani = new User()
        {
            Id = "dani",
            Name = "dani",
            Password = "123456789",
            Server = "localhost:1234",
            Contacts = new List<Contact> { }
        };



        public Contact noamTheContact = new Contact()
        {
            Id = "noam",
            Name = "nono",
            Server = "localhost:1234",
            Last = "22",
            Lastdate = ""
        };
        public Contact itayTheContact = new Contact()
        {
            Id = "itay",
            Name = "itay",
            Server = "localhost:1234",
            Last = "11",
            Lastdate = ""
        };

        private static readonly List<User> _users = new List<User>() { };

        private static readonly List<Chat> _chats = new List<Chat>(){ };

        public ContactsService()
        {
  
            _users.Add(yossi);

        }

        public List<Contact> GetAllContacts(string connectContactId)
        {
            if (_users.Exists(u => u.Id == connectContactId))
            {
                return _users.FirstOrDefault(u => u.Id == connectContactId).Contacts;
            }

            return null;
        }

        public Contact GetContact(string connectContactId, string contactId)


        {
            if (_users.FirstOrDefault(u => u.Id == connectContactId) != null)
            {
                return _users.FirstOrDefault(u => u.Id == connectContactId).Contacts.FirstOrDefault(c => c.Id == contactId);
            }
            return null;
        }

        public int CreateContact(string connectedId,Contact contact)
        {
            User user = _users.FirstOrDefault(u => u.Id == connectedId);

            if (user != null && user.Contacts.FirstOrDefault(u => u.Id == contact.Id) == null)
            {
                      user.Contacts.Add(contact);

                if (_chats.Exists(chat => (chat.User1 == connectedId && chat.User2 == contact.Id) || (chat.User2 == connectedId && chat.User1 == contact.Id)))
                {
                    return 1;
                }
                _chats.Add(new Chat() { Id = _chats.Count() + 1, User1 = connectedId, User2 = contact.Id, Messages = new List<Message>() });
                return 1;
            }
            return 0;
            
        }

        public int UpdateContact(string connectContactId,string destId,string Name,string Server)
        {
            if(_users.FirstOrDefault(u => u.Id == connectContactId) == null)
            {
                return 0;
            }
            Contact c = _users.FirstOrDefault(u => u.Id == connectContactId).Contacts.FirstOrDefault(c => c.Id ==destId);
            if(c == null)
            {
                return 0;
            }
            c.Name = Name;
            c.Server = Server;
            return 1;

        }

        public int DeleteContact(string connectContactId, string contactId)
        {
            if (_users.FirstOrDefault(u => u.Id == connectContactId) == null)
            {
                return 0;
            }

            Contact contact =_users.FirstOrDefault(u => u.Id == connectContactId).Contacts.FirstOrDefault(u=>u.Id==contactId);
            if (contact == null)
            {
                return 0;
            }

            _users.FirstOrDefault(u => u.Id == connectContactId).Contacts.Remove(GetContact(connectContactId, contactId));
            return 1;
        }

        public int CreateMessage(string connectContactId, string destContactId,string content)
        {
            Chat chat=_chats.FirstOrDefault(c => (c.User1 == connectContactId && c.User2 == destContactId) || c.User2 == connectContactId && c.User1 == destContactId);
            if (chat == null)
            {
                return 0;
            }
            int id;
            if (chat.Messages.Count() == 0)
            {
                id = 0;
            }
            else
            {
                id = chat.Messages[chat.Messages.Count()-1].Id + 1;
            }
            
            bool sent = chat.User1 == connectContactId;
            string date = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffffff");
            Message message = new() { Id = id, Sent = sent, Created = date, Content = content };
            chat.Messages.Add(message);


            User user1 = _users.FirstOrDefault(u => u.Id == connectContactId);
            if(user1 == null)
            {
                return 0;
            }

            Contact contact = user1.Contacts.FirstOrDefault(x => x.Id == destContactId);
            if (contact != null) {
                contact.Last = content;
                contact.Lastdate = date;
            }


            User user2 = _users.FirstOrDefault(x => x.Id == destContactId);
            if (user2 == null && user1.Contacts.Exists(u => u.Id == destContactId))
            {
                return 1;
            }

            contact = user2.Contacts.FirstOrDefault(x => x.Id == connectContactId);
            if (contact != null)
            {
                contact.Last = content;
                contact.Lastdate = date;
            }

            //_users.FirstOrDefault(x => x.Id == connectContactId).Contacts.FirstOrDefault(x => x.Id == destContactId).Lastdate = date;
            return 1;
        }

        public Message GetMessageById(string connectContactId, string destContactId, int messageId)
        {
            Chat chat = _chats.FirstOrDefault(c => (c.User1 == connectContactId && c.User2 == destContactId) || c.User2 == connectContactId && c.User1 == destContactId);
            if (chat == null)
            {
                return null;
            }

            Message message= chat.Messages.FirstOrDefault(m => m.Id == messageId);
            if (message == null)
            {
                return null;
            }

            if (chat.User1== connectContactId)
            {
                return message;
            }
            // for changing the sent fiels to the oposite value
            return new Message() { Id = messageId, Content = message.Content, Created = message.Created, Sent = false };
            }
            
        

        public List<Message> GetAllMessages(string connectContactId, string destContactId)
        {
        Chat chat = _chats.FirstOrDefault(c => (c.User1 == connectContactId && c.User2 == destContactId) || c.User2 == connectContactId && c.User1 == destContactId);
            if (chat == null)
            {
                return null;
            }


            if (chat.User1 == connectContactId)
            {
                return chat.Messages;
            }

            // for changing the sent fiels to the oposite value
            List<Message> messages =new List<Message>();
                foreach (Message message in chat.Messages) {
                    messages.Add(new Message() { Id = message.Id, Content = message.Content, Created = message.Created, Sent = !message.Sent });
                }
            return messages;
        }

        public int UpdateMessageById(string connectContactId, string destContactId, int messageId, string message)
        {
            Chat chat = _chats.FirstOrDefault(c => (c.User1 == connectContactId && c.User2 == destContactId) || c.User2 == connectContactId && c.User1 == destContactId);
            if (chat == null)
            {
                return 0;
            };

            Message mess = chat.Messages.FirstOrDefault(m => m.Id == messageId);

            if (mess == null)
            {
                return 0;
            }
            // change the last message for contact if it match
            if(mess.Id == chat.Messages[chat.Messages.Count() - 1].Id)
            {
                User us1 = _users.FirstOrDefault(u => u.Id == chat.User1);
                User us2 = _users.FirstOrDefault(u => u.Id == chat.User2);
                if (us1 != null)
                {
                    Contact co1 = us1.Contacts.FirstOrDefault(u => u.Id == chat.User2);
                    if (co1 != null)
                    {
                        co1.Last = message;
                        co1.Lastdate = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffffff");


                    }
                }
                if (us2 != null)
                {
                    Contact co2 = us2.Contacts.FirstOrDefault(u => u.Id == chat.User1);
                    if (co2 != null)
                    {
                        co2.Last = message;
                        co2.Lastdate = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffffff");
                    }
                }


                }
            mess.Content = message;
            
            return 1;

        }

        public int DeleteMessageById(string connectContactId, string destContactId, int messageId)
        {
           Chat chat=_chats.FirstOrDefault(c => (c.User1 == connectContactId && c.User2 == destContactId) || c.User2 == connectContactId && c.User1 == destContactId);
            if (chat == null)
            {
                return 0;
            };

            Message message =chat.Messages.FirstOrDefault(m=>m.Id == messageId);
            if (message == null)
            {
                return 0;
            };

            chat.Messages.Remove(chat.Messages.FirstOrDefault(m => m.Id == messageId));

            return 1;
        }

        public int InviteContact(string from, string to, string server)
        {
            return CreateContact(to, new Contact() { Id = from, Name = from, Server = server, Last = "", Lastdate = "" });

        }

        public int TransferMessage(string from, string to, string content)
        {
            Chat chat = _chats.FirstOrDefault(c => (c.User1 == from && c.User2 == to) || c.User2 == from && c.User1 == to);
            if (chat == null)
            {
                return 0;
            }

            int id;
            if (chat.Messages.Count() == 0)
            {
                id = 0;
            }
            else
            {
                id = chat.Messages[chat.Messages.Count() - 1].Id + 1;
            }
            bool sent = chat.User1 == from;
            string date = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffffff");
            Message message = new() { Id = id, Sent = sent, Created = date, Content = content };
            chat.Messages.Add(message);


            User user1 = _users.FirstOrDefault(u => u.Id == to);
            if (user1 == null)
            {
                return 0;
            }

            Contact contact = user1.Contacts.FirstOrDefault(x => x.Id == from);
            if (contact != null)
            {
                contact.Last = content;
                contact.Lastdate = date;
            }
              return 1;
        }

        /////////////////////////////////////////////////////////////
        ///

        public User GetUser(string id)
        {
            foreach (var user in _users) {
                if (user.Id == id)
                {
                        return user;
                }
            }
            return null;
        }

        public List<User> GetAllUsers()
        {
            return _users;
        }

        public List<Chat> GetChats(string id)
        {
            return _chats;
        }

        public int CreateUser(User user)
        {
            _users.Add(user);
   
            return 1;
        }

        public User GetUserById(string id)
        {
            User user = _users.FirstOrDefault(c => c.Id == id);
            if (user != null)
            {
                return user;
            }
            return null;
        }
    }
}
