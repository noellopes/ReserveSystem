using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
    public class Room
    {
        [Key][Required] public int ID_ROOM { get; set; }

        [ForeignKey("RoomType")][Required] public int RoomTypeId { get; set; }

        public RoomType RoomType { get; set; }



        
        

    }
}
