using System.ComponentModel.DataAnnotations;

namespace noam2.Model
{
    public class Chat
    {


        [Key]
        public int Id { get; set; }

        [Required]
        public string  User1 { get; set; }
        [Required]
        public string  User2 { get; set; }
        [Required]
        public List<Message> Messages { get; set; }


    }
}
