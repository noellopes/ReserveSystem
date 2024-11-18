namespace ReserveSystem.Models

{
    public class Staff
    {
        [Key]
        [Required]
        public int StaffID { get; set; }
        [Required]
        [ForeignKey("Job")]
        public int JobId { get; set; }

        [Required]
        [StringLenght(100)]
        public string StaffName { get; set; }
        [Required]
        public string StaffEmail { get; set; }

        [StringLenght(50)]
        public string StaffDept { get; set; }
        public string StaffPhone { get; set; }
        [Required]
        [MinLenght(8)]
        public string StaffPassword { get; set; }

        [Required]
        public string StartFunctionsDate { get; set; }
        public string EndFunctionsDate { get; set; }
        public int DaysOffVacation { get; set; }

    }
}
