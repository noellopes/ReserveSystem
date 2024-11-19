using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
    public class Staff
    {
        // Primary Key
        // StaffId: INT
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StaffId { get; set; }

        // Foreign Keys
        // JobId: INT
        [Required]
        public required int JobId { get; set; }

        [ForeignKey("JobId")]
        public required virtual Job Job { get; set; }

        // Attributes
        // StaffName: STRING
        [Required]
        [DataType(DataType.Text)]
        [MinLength(3)]
        [StringLength(50)]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z\s]+$")]
        [Display(Name = "Staff Name")]
        [Column(TypeName = "VARCHAR(50)")]
        public required string StaffName { get; set; }

        // StaffEmail: STRING
        [Required]
        [DataType(DataType.EmailAddress)]
        [MinLength(5)]
        [StringLength(50)]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
        [Display(Name = "Staff Email")]
        [Column(TypeName = "VARCHAR(50)")]
        public required string StaffEmail { get; set; }

        // StaffPhone: STRING
        [Required]
        [DataType(DataType.PhoneNumber)]
        [MinLength(9)]
        [StringLength(9)]
        [MaxLength(9)]
        [RegularExpression(@"^[0-9]+$")]
        [Display(Name = "Staff Phone")]
        [Column(TypeName = "VARCHAR(9)")]
        public required string StaffPhone { get; set; }

        // StaffPassword: STRING
        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        [StringLength(8)]
        [MaxLength(128)]
        [RegularExpression(@"^[a-zA-Z0-9]+$")]
        [Display(Name = "Staff Password")]
        [Column(TypeName = "VARCHAR(128)")]
        public required string StaffPassword { get; set; }

        // HireDate: DATETIME
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Hire Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "DATETIME")]
        public required DateTime HireDate { get; set; }

        // DismissalDate: DATETIME
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Dismissal Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "DATETIME")]
        public required DateTime DismissalDate { get; set; }

        // VacationDays: INT
        [Required]
        [DataType(DataType.Text)]
        [Range(0, 366)]
        [Display(Name = "Vacation Days")]
        [DisplayFormat(DataFormatString = "{0:0}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "INTEGER")]
        [RegularExpression(@"^[0-9]+$")]
        public required int VacationDays { get; set; }

        // Methods for reference only, business logic should be in the controller
        // ConsultStaff()
        // SelectStaff()
    }
}