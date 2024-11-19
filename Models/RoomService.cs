using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
    public class RoomService
    {
        // Primary Key
        // RoomServiceId: INT
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required int RoomServiceId { get; set; }

        // Foreign Keys
        // JobId: INT
        [Required]
        public required int JobId { get; set; }

        [ForeignKey("JobId")]
        public required virtual Job Job { get; set; }

        // Attributes
        // RoomServiceName: STRING
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Room Service Name")]
        [DisplayFormat(NullDisplayText = "No room service name, room service name is null!")]
        [Column(TypeName = "VARCHAR")]
        [MinLength(1)]
        [StringLength(50)]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Room Service Name must only contain letters")]
        public required string RoomServiceName { get; set; }

        // RoomServiceDescription: STRING
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Room Service Description")]
        [DisplayFormat(NullDisplayText = "No room service description, room service description is null!")]
        [Column(TypeName = "VARCHAR")]
        [MinLength(1)]
        [StringLength(100)]
        [MaxLength(100)]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Room Service Description must only contain letters")]
        public required string RoomServiceDescription { get; set; }

        // RoomServicePrice: DOUBLE
        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Room Service Price")]
        [DisplayFormat(NullDisplayText = "No room service price, room service price is null!")]
        [Column(TypeName = "DECIMAL(10,2)")]
        [Range(0.01, 999999.99, ErrorMessage = "Room Service Price must be between 0.01 and 999999.99")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Room Service Price must be a number with up to 2 decimal places")]
        public required double RoomServicePrice { get; set; }

        // RoomServiceActive: BOOLEAN
        [Required]
        [Display(Name = "Room Service Active")]
        [DisplayFormat(NullDisplayText = "No room service active status, room service active status is null!")]
        [Column(TypeName = "BOOLEAN")]
        public required bool RoomServiceActive { get; set; }

        // RoomServiceDuration: INT
        [Required]
        [DataType(DataType.Duration)]
        [Display(Name = "Room Service Duration")]
        [DisplayFormat(NullDisplayText = "No room service duration, room service duration is null!")]
        [Column(TypeName = "INT")]
        [Range(1, 999, ErrorMessage = "Room Service Duration must be between 1 and 999")]
        [RegularExpression(@"^[0-9]{1,3}$", ErrorMessage = "Room Service Duration must be a number between 1 and 999")]
        public required int RoomServiceDuration { get; set; }

        // Methods for reference only, business logic should be in the controller
        // ConsultRoomService()
        // InsertRoomService()
        // UpdateRoomService()
        // DeactivateRoomService()
        // SelectRoomService()
    }
}