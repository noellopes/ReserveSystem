namespace ReserveSystem.Models
{
    public class Staff
    {
        public int StaffId { get; set; }
        public required string StaffName { get; set; }
        public required string StaffEmail { get; set; }
        public required string StaffPhone { get; set; }
        public required string StaffDriverLicense { get; set; }
        public DateTime StaffDriverLicenseExpiringDate { get; set; }
        public bool IsActive { get; set; }

        public int JobId { get; set; }
        public Job job { get; set; }

        public ICollection<CleaningShedule> cleaningSchedules { get; set; }
    }
}
