namespace ReserveSystem.Models
{
	public class ExcursaoViewModel
	{

		public IEnumerable<ExcursaoModel> Excursao { get; set; }

		// Informações de paginação
		public PagingInfo PagingInfo { get; set; }

		// Campos de busca
		public string SearchTitulo { get; set; }
		
		public string SearchData { get; set; }

		// Parâmetros para ordenação
		public string CurrentSort { get; set; }
		public string PrecoSortParm { get; set; }
		public string DateSortParm { get; set; }

		// Filtros atuais
		public string CurrentFilter { get; set; }
	}
}
