using System.ComponentModel.DataAnnotations;


namespace pc_desk_rest.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]  
        public string UserName { get; set; } = string.Empty;

        [Required]
        public int PhoneNumber { get; set; }

    }
}
