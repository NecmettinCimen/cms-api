using System.ComponentModel.DataAnnotations;

namespace cms_api.Models
{
    public class Page:AuditModel
    {
        [Required]
        [MaxLength(100)]
        public string Type { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

    }
}