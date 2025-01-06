namespace ReserveSystem.Models
{
    public class RoomTypeViewModel
    {
        public IEnumerable<RoomType> RoomType { get; set; }
        public PagingInfo PagingInfo { get; set; }

        public string searchQuery { get; set; }
    }
}
