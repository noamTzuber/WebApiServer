using System.ComponentModel.DataAnnotations;

namespace noam2.Model
{
    public class Contact
    {


        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public string Server { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Img { get; set; }

        public List<int> Chats { get; set; }
    }
}
