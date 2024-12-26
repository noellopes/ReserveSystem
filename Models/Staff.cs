namespace ReserveSystem.Models
{
    public class Staff
    {
        public int StaffId { get; set; }
        public required string StaffName { get; set; }
        public required string StaffEmail { get; set; }
        public required string StaffPhone { get; set; }
        public required string StaffDriversLicense { get; set; }
        public DateTime StaffDriversLicenseExpiringDate { get; set; }
        public DateTime StaffDateOfBirth { get; set; }
        public required string StaffPassword { get; set; }
        public DateTime StartFunctionsDate { get; set; }
        public DateTime EndFunctionsDate { get; set; }
        public required int DaysOfVacationCount { get; set; }
        public bool IsActive { get; set; }

        public int JobId { get; set; }
        public Job job { get; set; }

        //public ICollection<CleaningShedule> cleaningSchedules { get; set; }
    }
}
