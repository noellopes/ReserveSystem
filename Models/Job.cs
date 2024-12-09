namespace ReserveSystem.Models
{
    public class Job
    {
        public int JobId { get; set; }
        public required string JobName { get; set; }
        public required string JobDescription { get; set; }
        public float Salary { get; set; }

        public ICollection<Staff> staffMembers { get; set; }
    }
}
