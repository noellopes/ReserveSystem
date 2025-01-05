using ReserveSystem.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[ShiftTimeValidation]
public class Schedules
{
    [Key]
    public int SchedulesId { get; set; }

    [Required(ErrorMessage = "StartShiftTime is required.")]
    [DataType(DataType.Time, ErrorMessage = "StartShiftTime is not a valid time.")]
    public TimeSpan StartShiftTime { get; set; }

    [Required(ErrorMessage = "EndShiftTime is required.")]
    [DataType(DataType.Time, ErrorMessage = "EndShiftTime is not a valid time.")]
    public TimeSpan EndShiftTime { get; set; }

    [Required(ErrorMessage = "isPrecense is required.")]
    public bool isPrecense { get; set; }

    [Required(ErrorMessage = "isAvailable is required.")]
    public bool isAvailable { get; set; }

    [Required(ErrorMessage = "StaffId is required.")]
    public int StaffId { get; set; }
    public Staff? staff { get; set; }

    [Required(ErrorMessage = "TypeOfScheduleId is required.")]
    public int TypeOfScheduleId { get; set; }
    public TypeOfSchedule? typeOfSchedule { get; set; }
}
