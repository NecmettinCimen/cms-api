using System.ComponentModel.DataAnnotations;

namespace cms_api.Models
{
    public class Menu:AuditModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string Link { get; set; }

    }
}