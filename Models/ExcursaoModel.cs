using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
	public class ExcursaoModel
	{
		[Key]
		public int Excursao_Id { get; set; }
		[Required]
		public string Titulo { get; set; }
		
		public string Descricao { get; set; }
		
		public DateTime Data_Inicio{get; set;}
		public DateTime Data_Fim { get; set; }
		public int Preco {  get; set; }

		public int Staff_Id { get; set; }

		public StaffTestModel? Staff { get; set; }

	}

}
