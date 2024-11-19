using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ReserveSystem.Models
{
    public class RoomService
    {
        [Key] public int ID_RoomService { get; set; }

        [Required, Display(Name = "Job ID")]
        [ForeignKey("Job")]
        public int Job_ID { get; set; }

        [Required, StringLength(150), Display(Name = "Name")]
        public string Room_Service_Name { get; set; }

        [StringLength(300), Display(Name = "Description")]
        public string? Room_Service_Description { get; set; }

        [Required(ErrorMessage = "Room Service Price is required."), Display(Name = "Price")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Room Service Price must be greater than 0.")]
        public double Room_Service_Price { get; set; }

        [Required, Display(Name = "Active")]
        public Boolean Room_Service_Active { get; set; }

        [Required, Display(Name = "Limit per hour")]
        public int Room_Service_Limit_Hour { get; set; }

    }
}

