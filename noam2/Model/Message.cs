using System.ComponentModel.DataAnnotations;

namespace noam2.Model
{
    public class Message
    {


        [Key]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public string Sender { get; set; }
        [Required]
        public string Type { get; set; }

        public string Date { get; set; }




    }
}
