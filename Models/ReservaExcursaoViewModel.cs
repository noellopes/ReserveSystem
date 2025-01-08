using System.Collections.Generic;

namespace ReserveSystem.Models
{
    public class ReservaExcursaoViewModel
    {
        // Lista de reservas exibidas na página
        public IEnumerable<ReservaExcursaoModel> Reservas { get; set; }

        // Informações de paginação
        public PagingInfo PagingInfo { get; set; }

        // Campos de busca
        public string SearchTitulo { get; set; }
        public string SearchCliente { get; set; }
        public string SearchData { get; set; }

        // Parâmetros para ordenação
        public string CurrentSort { get; set; }
        public string NameSortParm { get; set; }
        public string DateSortParm { get; set; }

        // Filtros atuais
        public string CurrentFilter { get; set; }
    }
}
