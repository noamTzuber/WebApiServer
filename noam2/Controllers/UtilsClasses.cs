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
        public string ConnectedId { get; set; }

        public string Name { get; set; }
        public string Server { get; set; }

    }
    public class ContactCreate
    {
        public string ConnectedId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Server { get; set; }

    }


    public class MessageData
    {
        public string ConnectedId { get; set; }
        public string Content { get; set; }

    }

}
