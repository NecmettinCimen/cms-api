using System.ComponentModel.DataAnnotations;

namespace cms_api.Models
{
    public class Parameter:AuditModel
    {
        [Required]
        [MaxLength(100)]
        public string Code { get; set; }

        [Required]
        [MaxLength(500)]
        public string Value { get; set; }

    }
}