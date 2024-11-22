using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Client
    {
        public int ClientId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Invalid Name")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Phone is required.")]
        [Phone(ErrorMessage = "Invalid phone number format.")]
        [StringLength(9, ErrorMessage = "Invalid Phone Number(9 chars only)")]
        public required string Phone { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        [StringLength(256, ErrorMessage = "Invalid Email Address.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Clean preference is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format.")]
        public DateTime CleanPreference { get; set; }

        public bool IsCleanPreferenceValid()
        {
            return CleanPreference >= DateTime.Today;
        }

        //public DateTime CleanPreference
        //{
        //    get { return CleanPreference; }
        //    set { 
        //        if(value < DateTime.Today)
        //        {
        //            throw new ArgumentException("Clean Date Invalid. Must be >= than today day");
        //
        //       }
        //        CleanPreference = value;
        //    }
        //}

    }
}
