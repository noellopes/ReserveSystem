namespace ReserveSystem.Models
{
    public class RoomBookingViewModel
    {
        public int BookingId { get; set; }
        public List<RoomTypeSelection> RoomTypes { get; set; } = new List<RoomTypeSelection>();
        public DateOnly CheckInDate { get; set; }
        public DateOnly CheckOutDate { get; set; }
    }

    public class RoomTypeSelection
    {
        public int RoomTypeId { get; set; }
        public string Type { get; set; }
        public int RoomCapacity { get; set; }
        public int Beds { get; set; }
        public bool HasView { get; set; }
        public bool AcessibilityRoom { get; set; }
        public int SelectedQuantity { get; set; }
    }
}