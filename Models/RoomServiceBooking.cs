using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
    public class RoomServiceBooking
    {
        // Primary Key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomServiceBookingId { get; set; }

        // Foreign Keys
        [Required]
        public int RoomServiceId { get; set; }

        [Required]
        public int StaffId { get; set; }

        [Required]
        public int ClientId { get; set; }

        [Required]
        public int RoomId { get; set; }

        // Properties
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }  // Nullable for cases when end date is not yet set

        [Required]
        public bool IsReserved { get; set; } // True for Reserved, False for Cancelled

        public bool StaffConfirmation { get; set; } // True if concluded, False if not

        [Range(1, 5)]
        public int? ClientFeedback { get; set; } // Nullable to allow absence of feedback

        [Required]
        [DataType(DataType.Currency)]
        public decimal AmountToPay { get; set; }

        public bool PaymentMade { get; set; }

        // Methods (Optional) - Placeholder examples, typically implemented in a service layer
        public RoomServiceBooking GetRoomServiceBooking(int id)
        {
            throw new NotImplementedException();
        }

        public bool AddRoomServiceBooking(RoomServiceBooking booking)
        {
            throw new NotImplementedException();
        }

        public bool UpdateRoomServiceBooking(RoomServiceBooking booking)
        {
            throw new NotImplementedException();
        }

        public bool DeleteRoomServiceBooking(int id)
        {
            throw new NotImplementedException();
        }

        public bool AssignStaff(int staffId)
        {
            throw new NotImplementedException();
        }

        public bool ChangeReservationStatus(bool newStatus)
        {
            this.IsReserved = newStatus;
            return true; // Indicating success; modify as needed
        }
    }
}
