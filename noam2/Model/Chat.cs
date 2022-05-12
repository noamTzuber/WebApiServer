using System.ComponentModel.DataAnnotations;

namespace noam2.Model
{
    public class Chat
    {


        [Key]
        public int Id { get; set; }

        [Required]
        public List<string> Contacts { get; set; }

        public List<Message> Messages { get; set; }


    }
}
