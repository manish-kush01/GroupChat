using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GroupChat.Models
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        
        public string AssociatedGroups { get; set; }= string.Empty;
        public ICollection<Messages> Messages { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
