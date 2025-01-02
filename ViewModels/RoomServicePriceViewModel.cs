using Microsoft.AspNetCore.Mvc.Rendering;
using ReserveSystem.Models;
using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.ViewModels
{
    public class RoomServicePriceViewModel
    {
        // Lista de preços de serviços de quarto para exibição
        public IEnumerable<RoomServicePrice>? RoomServicePrices { get; set; }

        // Pesquisa por data
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime? SearchStartDate { get; set; }

        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime? SearchEndDate { get; set; }

        // Pesquisa por ID do serviço de quarto
        [Display(Name = "Room Service")]
        public int? SelectedRoomServiceId { get; set; }

        // Lista de serviços de quarto para o dropdown
        public SelectList? RoomServices { get; set; }

        // Informações de paginação
        public PagingInfo? PagingInfo { get; set; }
    }
}
