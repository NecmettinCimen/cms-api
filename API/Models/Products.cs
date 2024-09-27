
using System.ComponentModel.DataAnnotations;

namespace cms_api.Models
{
    public class Product:AuditModel
    {
        [Required]
        [MaxLength(500)]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(1000)]
        public string ShortDescription { get; set; }
        [Required]
        [MaxLength(10000)]
        public string Description { get; set; }
        [Required]
        [MaxLength(1000)]
        public string PrimaryPicturePath { get; set; }
        [Required]
        public double Price { get; set; }
        
    }
}