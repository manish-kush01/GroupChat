using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GroupChat.Models
{
    public class Messages
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MessageId { get; set; }
        [Required]
        public string Message { get; set; }=string.Empty;
        [Required]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public Users User { get; set; }
        [ForeignKey("GroupId")]
        public Groups Group { get; set; }
        [Required]
        public int GroupId { get; set; }
        public DateTime SentTime { get; set; }
    }
}
