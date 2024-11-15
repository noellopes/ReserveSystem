namespace ReserveSystem.Models

{
    public class Staff
    {
        [Key]
        [Required]
        public int StaffID { get; set; }
        public string StaffName { get; set; }
        public string StaffEmail { get; set; }
        public string StaffDept { get; set; }
        public string StartFunctionsDate { get; set; }
        public string EndFunctionsDate { get; set; }
        public int JobId { get; set; }

    }
}
