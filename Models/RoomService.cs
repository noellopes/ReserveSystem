using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ReserveSystem.Models
{
    public class RoomService
    {
        [Key] public int ID_Room_Service { get; set; }

        [Required, Display(Name = "Job")]
        [ForeignKey("Job")]
        public int Job_ID { get; set; }
        public Job Job { get; set; } // Propriedade de Navegação

        [Required, StringLength(150), Display(Name = "Name")]
        public string Room_Service_Name { get; set; }

        [StringLength(350), Display(Name = "Description")]
        public string? Room_Service_Description { get; set; }

        [Required, Display(Name = "Active")]
        public bool Room_Service_Active { get; set; }

    }
}

