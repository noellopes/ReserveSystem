﻿using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Cleaning_Schedule
    {
        [Key]
        public int CleaningScheduleId { get; set; }
        public int RoomBookingId { get; set; }
        public Room_Booking? room_Booking { get; set; }
        public int ClientId { get; set; }
        public Client? client { get; set; }
        public int StaffId { get; set; }
        public Staff? staffMembers { get; set; }

        [Required(ErrorMessage = "DateServices is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid format for DateServices.")]
        public DateTime DateServices { get; set; }

        [Required(ErrorMessage = "StartTime is required.")]
        [DataType(DataType.Time, ErrorMessage = "Invalid format for StartTime.")]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "EndTime is required.")]
        [DataType(DataType.Time, ErrorMessage = "Invalid format for EndTime.")]
        public DateTime EndTime { get; set; }

        [Required(ErrorMessage = "CleaningDone is required.")]
        public bool CleaningDone { get; set; } = false;

        // Novos campos de preferência do cliente
        [Required(ErrorMessage = "CleaningDesired is required.")]
        public bool CleaningDesired { get; set; }  // Indica se o cliente deseja a limpeza

        [DataType(DataType.Time, ErrorMessage = "Invalid format for PreferredCleaningStartTime.")]
        public DateTime? PreferredCleaningStartTime { get; set; }  // Horário preferido de início da limpeza

        [DataType(DataType.Time, ErrorMessage = "Invalid format for PreferredCleaningEndTime.")]
        public DateTime? PreferredCleaningEndTime { get; set; }  // Horário preferido de fim da limpeza
        

        public static ValidationResult ValidateTimeRange(DateTime startTime, ValidationContext context)
        {
            if (startTime >= ((Cleaning_Schedule)context.ObjectInstance).EndTime)
            {
                return new ValidationResult("StartTime must be before EndTime.");
            }
            return ValidationResult.Success;
        }
    }
}
