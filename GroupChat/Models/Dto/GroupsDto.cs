using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GroupChat.Models.Dto
{
    public class GroupsDto
    {
        [Required]
        public string GroupName { get; set; } = string.Empty;
        [Required]
        public string GroupType { get; set; } = string.Empty;
        [Key]
        public int GroupId { get; set; }
    }
}
