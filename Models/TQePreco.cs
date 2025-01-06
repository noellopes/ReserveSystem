using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class TQePreco
    {
        [Key]
        [Required]
        
        public int RoomTypeId { get; set; }

        [Required(ErrorMessage = "Please enter the name of the room type")]
        [MaxLength(25)]
       
        public string type { get; set; }

        [Required(ErrorMessage = "Please enter the total capacity of the room type")]
        public int capacity { get; set; }

        [Required(ErrorMessage = "Please enter the quantity of this type of room in the hotel")]
        public int RoomQuantity { get; set; }


        [Required(ErrorMessage = "Please mark whether this room has accesibility adjustments")]
        public bool AcessibilityRoom { get; set; }

        [Required(ErrorMessage = "Please mark if this room has a view")]
        public bool View { get; set; }

        [Required(ErrorMessage = "Please enter the base price for this room type")]
        public float BasePrice { get; set; }

        [Required]
        public float CancelationFee => BasePrice / 2;

       [Required(ErrorMessage = "Please enter the price of additional beds for this room type")]
        public float AdicionalBeds { get; set; }

        [Required]
        public bool InUse {  get; set; }

        


    }
}
