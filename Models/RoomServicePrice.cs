using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    [CustomValidation(typeof(RoomServicePrice), nameof(ValidateDateRange))]
    public class RoomServicePrice
    {
        [Key] public int ID_Room_Service_Price { get; set; }

        [Required, Display(Name = "Room Service")]
        [ForeignKey("RoomService")]
        public int ID_Room_Service { get; set; }
        public RoomService RoomService { get; set; } // Propriedade de Navegação

        [Required, Display(Name = "Start Date")]
        public DateTime Start_Date { get; set; }

        [Required, Display(Name = "End Date")]
        public DateTime? End_Date { get; set; }

        [Required(ErrorMessage = "Room Service Price is required."), Display(Name = "Price")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Room Service Price must be greater than 0.")]
        public double Room_Service_Price { get; set; }

        public static ValidationResult? ValidateDateRange(RoomServicePrice price, ValidationContext context)
        {
            if (price.End_Date.HasValue && price.Start_Date > price.End_Date.Value)
            {
                return new ValidationResult("Start Date must be earlier than or equal to End Date.");
            }
            return ValidationResult.Success;
        }
      

    }


}
