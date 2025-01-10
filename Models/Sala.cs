using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ReserveSystem.Models;

public class Sala
{
    [Key] public long IdSala { get; set; }

    [Required(ErrorMessage = "The 'Preparation Time' field is required.")]
    [Range(typeof(TimeSpan), "00:00:01", "23:59:59",
        ErrorMessage = "The 'Preparation Time' must be between 1 second and 24 hours.")]
    public TimeSpan TempoPreparação { get; set; }

    [Required(ErrorMessage = "The 'Start Time' field is required.")]
    public TimeOnly HoraInicio { get; set; }

    [Required(ErrorMessage = "The 'End Time' field is required.")]
    public TimeOnly HoraFim { get; set; }

    [Required(ErrorMessage = "The 'Floor' field is required.")]
    [Range(0, int.MaxValue, ErrorMessage = "The 'Floor' must be zero or a positive integer.")]
    public int Floor { get; set; }

    [Required(ErrorMessage = "The 'Room Number' field is required.")]
    [Range(100, int.MaxValue, ErrorMessage = "The 'Room Number' must be 100 or higher.")]
    public int RoomNumber { get; set; }

    [Required(ErrorMessage = "The 'Room Type ID' field is required.")]
    [ForeignKey("TipoSala")]
    public long IdTipoSala { get; set; }

    public TipoSala? TipoSala { get; set; }
}