using System.ComponentModel.DataAnnotations;


namespace ReserveSystem.Models
{
	public class PrecarioModel
	{
		[Key]
		public int PrecoId { get; set; }

		[Required, Display(Name = "Preço")]
		public float Preco { get; set; }

		public DateTime Data_Inicio { get; set; }

		public int ExcursaoId { get; set; }
		public virtual ExcursaoModel? Excursao { get; set; }
	}
}
