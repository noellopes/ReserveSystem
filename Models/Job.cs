namespace ReserveSystem.Models
{
    public class Job
    {
        public int JobId { get; set; }
        public string JobName { get; set; }
        public string JobDescription { get; set; }
        public float Salary { get; set; }

        public ICollection<Staff> staffMembers { get; set; }
    }
}
