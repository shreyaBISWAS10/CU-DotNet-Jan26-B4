using System.ComponentModel.DataAnnotations;

namespace FinTrackPro.Models
{
    public class Account
    {
        public int Id { get; set; }

        [Required]
        public string AccountName { get; set; }

        public double Balance { get; set; }
    }
}
