﻿using Microsoft.AspNetCore.Mvc;
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
             return _users.FirstOrDefault(u => u.Id == connectContactId).Contacts.FirstOrDefault(c => c.Id == contactId);
        }

        public int CreateContact(string connectedId,Contact contact)
        {
            
            if ( _users.Exists(u => u.Id == connectedId))
            {
                _users.FirstOrDefault(u => u.Id == connectedId).Contacts.Add(contact);

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

            int id = chat.Messages.Count() + 1;
            bool sent = chat.User1 == connectContactId;
            string date = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffffff");
            Message message = new() { Id = id, Sent = sent, Created = date, Content = content };
            chat.Messages.Add(message);

            Contact contact = _users.FirstOrDefault(x => x.Id == connectContactId).Contacts.FirstOrDefault(x => x.Id == destContactId);
            if (contact != null) {
                contact.Last = content;
                contact.Lastdate = date;
            }
            contact = _users.FirstOrDefault(x => x.Id == destContactId).Contacts.FirstOrDefault(x => x.Id == connectContactId);
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
            mess.Content = message;
            return 0;

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

            chat.Messages.Remove(GetMessageById(connectContactId, destContactId, messageId));

            return 1;
        }

        public int InviteContact(string from, string to, string server)
        {
            return CreateContact(to, new Contact() { Id = from, Name = from, Server = server, Last = "", Lastdate = "" });

        }

        public int TransferMessage(string from, string to, string content)
        {
            return CreateMessage(from, to , content);
        }

        /////////////////////////////////////////////////////////////
        ///

        public User GetUser(string id)
        {
            foreach (var user in _users)
            {
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
