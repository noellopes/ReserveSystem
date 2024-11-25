namespace ReserveSystem.Models
{
    public class Cleaning
    {
        public int CleaningId { get; set; }
        public bool CleaningService { get; set; }

        public int RoomId { get; set; }
        public Room room { get; set; }

        public ICollection<CleaningShedule> cleaningSchedules { get; set; }
    }
}
