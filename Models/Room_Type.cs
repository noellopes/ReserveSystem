using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Room_Type
    {
        [Key]
        public int RoomTypeId { get; set; }

        [Required(ErrorMessage = "Please specify if the room has a view.")]
        public bool HasView { get; set; }

        [Required(ErrorMessage = "Room type is required.")]
        [StringLength(50, ErrorMessage = "Room type cannot exceed 50 characters.")]
        public required string Type { get; set; }

        [Required(ErrorMessage = "Capacity is required.")]
        [Range(1, 10, ErrorMessage = "Capacity must be between 1 and 10.")]
        public int Capacity { get; set; }

        [Required(ErrorMessage = "Room capacity is required.")]
        [Range(1, 10, ErrorMessage = "Room capacity must be between 1 and 10.")]
        public int RoomCapacity { get; set; }

        [Required(ErrorMessage = "Accessibility status is required.")]
        public bool AcessibilityRoom { get; set; }

        public ICollection<Room> ? rooms { get; set; }

    }
}