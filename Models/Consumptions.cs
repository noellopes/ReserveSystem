using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Consumptions
    {
        [Key]
        public int ConsumptionId { get; set; } 
        public int RoomId { get; set; } 
        public Room ? room { get; set; }
        public int ItemId { get; set; }
        public Items ? items { get; set; }

        [Required(ErrorMessage = "QuantityConsumed is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "QuantityConsumed must be at least 1.")]
        public int QuantityConsumed { get; set; }

        [Required(ErrorMessage = "ConsumedDate is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid format for ConsumedDate.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ConsumedDate { get; set; }
    }
}
