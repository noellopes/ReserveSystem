using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class UserLogin
    {
        [Key]
        public int Login_id { get; set; }

        [Required(ErrorMessage = "The ID is mandatory.")]
        public int Staff_id { get; set; }

        [Required(ErrorMessage = "The password is mandatory.")]
        public string Password { get; set; }

    }
}
