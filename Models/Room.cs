using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
    public class Room
    {
        // Primary Key
        // RoomId: INT
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required int RoomId { get; set; }

        // Foreign Keys
        // NONE

        // Attributes
        // RoomTypeId: INT
        [Required]
        [Display(Name = "Room Type")]
        [Column(TypeName = "INTEGER")]
        [DisplayFormat(NullDisplayText = "No room type, room type is null!")]
        public required int RoomTypeId { get; set; }

        // Methods for reference only, business logic should be in the controller
        
        // public void consultRoomNumber()
        
        // public void selectRoomNumber()
    }

}
