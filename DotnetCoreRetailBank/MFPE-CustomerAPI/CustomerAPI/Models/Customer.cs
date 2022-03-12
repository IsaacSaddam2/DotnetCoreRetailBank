using CustomerAPI.Utilities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerAPI.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [Required]
        [StringLength(255)]
        public string Address { get; set; }
        [Display(Name = "Date Of Birth")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [ValidAge(ErrorMessage = "Age Must be over 18")]
        public DateTime DOB { get; set; }
        [Required]
        [MinLength(10), MaxLength(10)]
        public string PAN_Number { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(8), MaxLength(16)]
        public string Password { get; set; }
        [Required]
        [MinLength(8), MaxLength(16)]
        [Compare("Password")]
        [NotMapped]
        public string ConfirmPassword { get; set; }
        public DateTime CreatedAt { get; } = DateTime.Now;
    }
}
