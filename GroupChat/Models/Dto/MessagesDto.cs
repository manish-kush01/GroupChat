using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GroupChat.Models.Dto
{
    public class MessagesDto
    {
        [Key]        
        public int MessageId { get; set; }
        [Required]
        public string Message { get; set; } = string.Empty;

        public Users User { get; set; } 

        [Required]
        public int UserId { get; set; }
        public Groups Group { get; set; }

        [Required]
        public int GroupId { get; set; }
        public DateTime SentTime { get; set; }
    }
}
