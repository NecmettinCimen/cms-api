using System.ComponentModel.DataAnnotations;

namespace cms_api.Models
{
    public class Skill:AuditModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        [MaxLength(500)]
        public string Icon { get; set; }

    }
}