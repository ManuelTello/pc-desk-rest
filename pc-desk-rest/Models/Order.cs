using System.ComponentModel.DataAnnotations;

namespace pc_desk_rest.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public User? User { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public decimal Cost { get; set; }

        [Required]
        public decimal Sign { get; set; }

        [Required]
        public DateTime DateIn { get; set; }

        public DateTime DateOut { get; set; }

    }
}
