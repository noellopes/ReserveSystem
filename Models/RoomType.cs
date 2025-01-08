using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class RoomType
    {
        [Required][Key] public int RoomTypeId { get; set; }

        [Required] public bool HasView { get; set; }

        [Required] public string Type { get; set; }

        [Required] public int RoomCapacity { get; set; }

        [Required] public bool AcessibilityRoom { get; set; }

        public ICollection<RoomModel> Rooms { get; set; }
    }
}
