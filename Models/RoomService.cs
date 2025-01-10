using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ReserveSystem.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class RoomService
    {

        [Required, Key, Display(Name = "Room Service Id"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "INTEGER")]
        [StringLength(50), MinLength(1), MaxLength(50)]
        public int Id { get; set; }

        // Fk Job Id
        [Required, ForeignKey("Job Id"), Display(Name = "Job Id")]
        [Column(TypeName = "INTEGER")]
        public int JobId { get; set; }

        [Required]
        [StringLength(256), MinLength(2), MaxLength(256)]
        [DataType(DataType.Text)]
        [Column(TypeName = "varchar(256)")]
        [Display(Name = "Name")]
        [DisplayFormat(DataFormatString = "{2,256}")]
        [RegularExpression(@"^[\w\s]{2,256}$", ErrorMessage = "Name must be between 2 and 256 characters")]
        public required string Name { get; set; }

        [Required]
        [StringLength(256), MinLength(2), MaxLength(256)]
        [DataType(DataType.Text)]
        [Column(TypeName = "varchar(256)")]
        [Display(Name = "Description")]
        [DisplayFormat(DataFormatString = "{2,256}")]
        [RegularExpression(@"^[\w\s]{2,256}$", ErrorMessage = "Description must be between 2 and 256 characters")]
        public required string Description { get; set; }

        // Price in euros €
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        [Display(Name = "Price")]
        [DisplayFormat(DataFormatString = "{0:C}"), Range(0, 999999.99)]
        [RegularExpression(@"^\d{1,8}(\.\d{1,2})?$", ErrorMessage = "Price must be a decimal number")]
        public required decimal Price { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        [Display(Name = "Service Status")]
        // If is 0 -> Deactivated, if is 1 -> Active
        [DisplayFormat(DataFormatString = "{0:Deactivated;Active}")]
        [RegularExpression(@"^[01]$", ErrorMessage = "Service Status must be 0 or 1")]
        public required bool ServiceActive { get; set; }

        // Service limit hours
        [Required]
        [Column(TypeName = "INTEGER")]
        [Display(Name = "Service Limit Hours")]
        // If set to 0, service is available 24/7, if set to 1, service is available for 1 hour, etc.
        [DisplayFormat(DataFormatString = "{0:24/7;1:Hr;0:Hrs}")]
        [RegularExpression(@"^\d{1,3}$", ErrorMessage = "Service Limit Hours must be a number")]
        public required int ServiceLimitHours { get; set; }

        // Navigation properties
        public Job? Job { get; set; }

        public List<RoomServiceBooking>? Bookings { get; set; }
    }
}