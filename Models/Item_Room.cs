using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Item_Room
    {
        [Key]
        public int ItemRoomId { get; set; }
        public int RoomTypeId { get; set; }
        public Room_Type ? roomType { get; set; }
        public int ItemId { get; set; }
        public Items ? items { get; set; }

        [Required(ErrorMessage = "Room quantity is required.")]
        [Range(1, 100, ErrorMessage = "Room quantity must be between 1 and 100.")]
        public int RoomQuantity { get; set; }
    }
}
