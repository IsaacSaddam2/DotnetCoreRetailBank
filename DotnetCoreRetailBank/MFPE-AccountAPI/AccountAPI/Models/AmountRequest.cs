using System.ComponentModel.DataAnnotations;

namespace AccountAPI.Models
{
    public class AmountRequest
    {
        [Required]
        public int AccountId { get; set; }
        [Range(0, double.MaxValue)]
        [Required]
        public double Amount { get; set; }
        public string Narration { get; set; }
    }
}
