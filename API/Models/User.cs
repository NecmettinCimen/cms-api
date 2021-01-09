using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace cms_api.Models
{
    public class User:BaseModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string SurName { get; set; }
        [Required]
        [MaxLength(150)]
        public string Email { get; set; }
        [Required]
        [MaxLength(150)]
        public string Password { get; set; }
        public DateTime? LastLoginDate { get; set; }
    }
}