using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Item_Room
    {
        public int ItemRoomId { get; set; }
        public int RoomTypeId { get; set; } 
        public int ItemId { get; set; }

        [Required(ErrorMessage = "Room quantity is required.")]
        [Range(1, 100, ErrorMessage = "Room quantity must be between 1 and 100.")]
        public int RoomQuantity { get; set; }
    }
}
