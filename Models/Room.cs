using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Room
    {
        [Key]
        public int ID_Room { get; set; }

        [Required]
        public int RoomTypeId { get; set; }
    }
}
