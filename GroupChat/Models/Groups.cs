using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GroupChat.Models
{
    public class Groups
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GroupId { get; set; }
        public string GroupName { get; set; } = string.Empty;
        
        public string GroupType { get; set; } = string.Empty;
        public ICollection<Messages> Messages { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
