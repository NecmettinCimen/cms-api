using System.ComponentModel.DataAnnotations;

namespace cms_api.Models
{
    public class Contact:AuditModel
    {
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

    }
}