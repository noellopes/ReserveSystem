
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
    public class Job
    {
        [Required, Key, Display(Name = "Room Service Id"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "INTEGER")]
        public int Id { get; set; }

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

        // Navigation properties
        public List<RoomService>? RoomServices { get; set; }

        public List<Staff>? Staffs { get; set; }
    }
}