namespace noam2.Controllers
{
    public class utilsClasses
    {
    }


    public class ConnectedId
    {
        public string connectedId { get; set; }
    }

    public class ContactUpdateData
    {

        public string Name { get; set; }
        public string Server { get; set; }

    }
    public class ContactCreate
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Server { get; set; }

    }


    public class MessageData
    {
        public string Content { get; set; }

    }

}
