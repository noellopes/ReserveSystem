namespace ReserveSystem.Models
{
	public class PrecarioViewModel
	{

		public IEnumerable<PrecarioModel> Precarios { get; set; }

		public PagingInfo PagingInfo { get; set; }

		public string SearchTitulo { get; set; }
		public string SearchData { get; set; }

		public string CurrentSort { get; set; }
		public string TituloSortParm { get; set; }
		public string DateSortParm { get; set; }
		public string CurrentFilter { get; set; }
	}
}
