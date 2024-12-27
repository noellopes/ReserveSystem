using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
    public class RoomModel
    {
        [Key][Required] public int ID_ROOM { get; set; }

        [Required][ForeignKey("RoomType")] public int RoomTypeId { get; set; }

       public RoomType RoomType { get; set; }
    }
}
