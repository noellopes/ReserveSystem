using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Rooms
    {
        [Key][Required] public int RoomTypeId {get; set;}

        [Required] public int RoomType {get; set;}

        [Required] public int Capacity {get; set;}

        [Required] public int NumberOfRooms { get;set;}

        [Required] public bool HasView {get; set;}

        [Required] public string AdaptedRoom { get; set; }


    }
}
