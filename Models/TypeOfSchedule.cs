using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models;

public class TypeOfSchedule
{
    [Key]
    [Required]
    public int TypeOfScheduleId { get; set; }  // Primary Key
    
    [Required]
    [DisplayName ("Name of Schedule") ]
    public string TypeOfScheduleName{ get; set; } // Schedule name
    
}