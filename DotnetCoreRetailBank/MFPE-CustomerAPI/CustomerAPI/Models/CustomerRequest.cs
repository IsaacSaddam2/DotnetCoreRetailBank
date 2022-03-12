using System.ComponentModel.DataAnnotations;

namespace CustomerAPI.Models
{
    public class CustomerRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(8), MaxLength(16)]
        public string Password { get; set; }
    }
}
