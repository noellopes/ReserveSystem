using Microsoft.AspNetCore.Mvc.Rendering;
using ReserveSystem.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.ViewModels
{
    public class RoomServiceViewModel
    {
        
        public IEnumerable<RoomService>? RoomServices { get; set; }
        public SelectList? RoomServicesIds { get; set; }
        public int? ID_Room_Service { get; set; }
        public string? Room_Service_Name { get; set; }
        public string? SearchName { get; set; }
        // Pesquisa por Tipo de Serviço / Job
        [Display(Name = "Job")]
        public int? Job_ID { get; set; } // ID do Job

        public SelectList? Jobs { get; set; } // Para o Dropdown de Jobs
        public PagingInfo? PagingInfo { get; set; }
    }
}

